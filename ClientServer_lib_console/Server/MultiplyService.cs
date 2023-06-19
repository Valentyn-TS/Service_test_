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

    public class MyCustomUserNameValidator : UserNamePasswordValidator
    {
        public override void Validate(string userName, string password)
        {
            if (null == userName || null == password)
            {
                Console.WriteLine("userName or password are Null...");
            }
            else if (!(userName == "test1" && password == "1test"))
            {
                Console.WriteLine("Unknown Username or Incorrect Password");
            }
            else Console.WriteLine("Status: Ok!");

        }
    }

    public class MultiplyService : IMultiplyService
    {
        public int Multiply(int x, int y)
        {
            return x * y;
        }

        public void MyValidator(string userName, string password)
        {
            MyCustomUserNameValidator Validator = new MyCustomUserNameValidator();
            Validator.Validate(userName, password);
        }
    }
}
