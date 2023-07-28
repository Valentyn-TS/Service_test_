using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Security;
using System.Text;
using System.Threading.Tasks;

namespace My_STS
{
    internal class CalculatorServiceHostFactory : ServiceHostFactoryBase
    {
        public override ServiceHostBase CreateServiceHost(string constructorString, Uri[] baseAddresses)
        {
            return new CalculatorServiceHost(baseAddresses);
        }
    }

    class CalculatorServiceHost : ServiceHost
    {
        public CalculatorServiceHost(params Uri[] addresses) : base(typeof(CalculatorService), addresses)
        {
            ServiceConstants.LoadAppSettings();
            this.Credentials.IssuedTokenAuthentication.CertificateValidationMode = X509CertificateValidationMode.PeerOrChainTrust;
        }
    }
}
