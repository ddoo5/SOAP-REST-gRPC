using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfService
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    public class Service1 : IService1
    {
        private readonly IStatisticsService _statisticsService;
        private readonly ISettingsService _settingsService;
        private readonly IScriptServices _scriptServices;

        public Service1()
        {
            _statisticsService = new StatisticsService();
            _settingsService = new SettingsService();
            _scriptServices = new ScriptService(_statisticsService, _settingsService, Callback);
        }


        public void RunScript()
        {
            _scriptServices.Run();
        }

        public void UpdateCompileScript(string fileName)
        {
            _settingsService.FileName = fileName;
            _scriptServices.Compile();
        }


        IServicesCallback Callback
        {
            get
            {
                if (OperationContext.Current != null)
                    return OperationContext.Current.GetCallbackChannel<IServicesCallback>();
                else
                    return null;
            }
        }
    }
}
