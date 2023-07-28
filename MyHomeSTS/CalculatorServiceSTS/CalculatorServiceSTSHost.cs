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
    class CalculatorServiceSTSHostFactory : ServiceHostFactoryBase
    {
        public override ServiceHostBase CreateServiceHost(string constructorString, Uri[] baseAddresses)
        {
            return new CalculatorServiceSTSHost(baseAddresses);
        }
    }

    class CalculatorServiceSTSHost : ServiceHost
    {
        public CalculatorServiceSTSHost(params Uri[] addresses) : base(typeof(CalculatorServiceSTS), addresses)
        {
            ServiceConstants.LoadAppSettings();
            this.Credentials.IssuedTokenAuthentication.CertificateValidationMode = X509CertificateValidationMode.PeerOrChainTrust;
        }
    }
}
