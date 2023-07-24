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
    public class MySTS: IMySTS
    {
        public int DoSomething()
        {
            int number = 123;
            return number;
        }
    }

    public class MySTS_AuthorizationManager : ServiceAuthorizationManager
    {
        public override bool CheckAccess(OperationContext operationContext)
        {
            AuthorizationContext authContext = operationContext.ServiceSecurityContext.AuthorizationContext;
            if (authContext.ClaimSets == null) return false;
            if (authContext.ClaimSets.Count != 1) return false;
            ClaimSet myClaimSet = authContext.ClaimSets[0];
            if (myClaimSet.Count != 1) return false;

            return true;
        }

    }
}
