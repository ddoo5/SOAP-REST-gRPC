using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfService
{
    [ServiceContract(Namespace= "http://microsoft.servicemodel.samples",SessionMode = SessionMode.Required, CallbackContract = typeof
        (IServicesCallback))]
    public interface IService1
    {
        [OperationContract]
        void RunScript();
        [OperationContract]
        void UpdateCompileScript(string fileName);
    }
}
