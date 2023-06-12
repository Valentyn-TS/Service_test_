using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SMS
{
    [ServiceContract]
    public interface IMesageService
    {
        [OperationContract]
        string GetMessage(string message);
    }
}
