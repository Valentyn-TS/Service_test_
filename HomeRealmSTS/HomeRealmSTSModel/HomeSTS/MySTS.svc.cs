using System;
using System.Collections.Generic;
using System.IdentityModel.Claims;
using System.IdentityModel.Policy;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HomeSTS
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class MySTS : IMySTS
    {

    }

    public class MySTS_AuthorizationManager : ServiceAuthorizationManager
    {
        public override bool CheckAccess(OperationContext operationContext)
        {
            return true;
        }

    }
}
