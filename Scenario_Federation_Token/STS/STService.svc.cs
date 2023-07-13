using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.ServiceModel.Activation;
using System.ServiceModel;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;

namespace STS
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "STService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select STService.svc or STService.svc.cs at the Solution Explorer and start debugging.
    public class STService : ISTService
    {
        public string GetToken()
        {
            return "I hear you! Take your Token!.... ";
        }
    }

}
