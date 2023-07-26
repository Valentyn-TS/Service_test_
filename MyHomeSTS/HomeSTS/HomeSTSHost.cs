using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Activation;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace My_STS
{
    public class HomeSTSHostFactory : ServiceHostFactoryBase
    {
        public override ServiceHostBase CreateServiceHost(string constructorString, Uri[] baseAddresses)
        {
            return new HomeSTSHost(baseAddresses);
        }
    }

    class HomeSTSHost : ServiceHost
    {
        public HomeSTSHost(params Uri[] addresses) : base(typeof(HomeSTS), addresses)
        {
            ServiceConstants.LoadAppSettings();
        }
    }
}
