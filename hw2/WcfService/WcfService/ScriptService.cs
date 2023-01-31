using Microsoft.CSharp;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace WcfService
{
    public class ScriptService : IScriptServices
    {
        private readonly IStatisticsService _statisticsService;
        private readonly ISettingsService _settingsService;
        private readonly IServicesCallback _servicesCallback;
        private CompilerResults _compilerResults = null;


        public ScriptService(IStatisticsService statisticsService, ISettingsService settingsService, IServicesCallback servicesCallback)
        {
            _statisticsService = statisticsService;
            _settingsService = settingsService;
            _servicesCallback = servicesCallback;
        }


        public bool Compile()
        {
            CompilerParameters parameters = new CompilerParameters();
            parameters.GenerateInMemory = true;
            parameters.ReferencedAssemblies.Add("System.dll");
            parameters.ReferencedAssemblies.Add("System.Data.dll");
            parameters.ReferencedAssemblies.Add("System.Core.dll");
            parameters.ReferencedAssemblies.Add("Microsoft.CSharp.dll");

            parameters.ReferencedAssemblies.Add(Assembly.GetExecutingAssembly().Location);

            FileStream stream = new FileStream(_settingsService.FileName, FileMode.Open);
            byte[] buffer;
            try
            {
                int lenght = (int)stream.Length;
                buffer = new byte[lenght];
                int count;
                int sum = 0;
                while ((count = stream.Read(buffer, sum, lenght - sum)) > 0)
                {
                    sum += count;
                }
            }
            finally
            {
                stream.Close();
            }

            CSharpCodeProvider provider = new CSharpCodeProvider();
            _compilerResults = provider.CompileAssemblyFromSource(parameters, System.Text.Encoding.UTF8.GetString(buffer));

            if (_compilerResults.Errors != null && _compilerResults.Errors.Count != 0)
            {
                string compileErrors = string.Empty;
                for (int i = 0; i < _compilerResults.Errors.Count; i++)
                {
                    if (compileErrors != string.Empty)
                    {
                        compileErrors += "\n";
                    }
                    compileErrors += _compilerResults.Errors[i];
                }

                return false;
            }

            return true;
        }

        public void Run()
        {
            if (_compilerResults == null || (_compilerResults != null && _compilerResults.Errors != null && _compilerResults.Errors.Count > 0))
            {
                if (Compile() == false)
                {
                    return;
                }
            }

            Type t = _compilerResults.CompiledAssembly.GetType("Example.SomeSampleScript");
            if (t == null)
            {
                return;
            }

            MethodInfo entryPoint = t.GetMethod("EntryPoint");
            if (entryPoint == null)
            {
                return;
            }

            Task.Run(() => {
                for (int i = 0; i < 101; i++)
                {
                    if ((bool)entryPoint.Invoke(Activator.CreateInstance(t), null))
                    {
                        _statisticsService.SuccessCount++;
                    }
                    else
                    {
                        _statisticsService.FailCount++;
                    }

                    _statisticsService.TotalCount++;

                    _servicesCallback.UpdateStatistics((StatisticsService)_statisticsService);
                    Thread.Sleep(350);
                }
            });
           
        }
    }
}