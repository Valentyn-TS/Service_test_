using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Security.Permissions;
using System.Text;

namespace Server
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class MultiplyService : IMultiplyService
    {
        public int Multiply(int x, int y)
        {
            return x * y;
        }

        public string GetLoginStatus()
        {
            string result = string.Empty;


            /*            if (!ServiceSecurityContext.Current.PrimaryIdentity.IsAuthenticated)
                            {
                                result = "User is not Authenticated";
                                return result;
                            }

                        result = string.Format("Date: {0}, AuthType: {1}, User: {2}", 
                            DateTime.Now.ToString(), 
                            ServiceSecurityContext.Current.PrimaryIdentity.AuthenticationType, 
                            ServiceSecurityContext.Current.PrimaryIdentity.Name);
                        return result;
            */
            return result = ServiceSecurityContext.Current.PrimaryIdentity.IsAuthenticated == null ? "No object. Null" : "++";
        }
    }
}
