using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Security.Permissions;
using System.IdentityModel.Selectors;
using System.IdentityModel.Tokens;

using System.ServiceModel.Description;
using System.ServiceModel.Security;

namespace Server
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]

    public class MultiplyService : IMultiplyService
    {
        public int Multiply(int x, int y)
        {
            return x * y;
        }

    }
}
