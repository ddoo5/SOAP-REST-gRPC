using ConsoleApp1.WcfServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WcfServiceUI;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Service1Client client = new Service1Client(new InstanceContext(new SimpleUI()));
            client.UpdateCompileScript(@"C:\Users\D\Desktop\WcfService\WcfService\SomeSampleScript.script");
            client.RunScript();

            Console.ReadKey(true);
            client.Close();
        }
    }
}
