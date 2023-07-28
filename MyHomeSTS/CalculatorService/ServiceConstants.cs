using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace My_STS
{
    class ServiceConstants
    {
        // The following two Action strings are the defaults created by the OperationContract attribute
        internal const string CalculatorAction = "http://tempuri.org/IBrowseBooks/BrowseBooks";

        // Statics for location of certs
        internal static StoreName CertStoreName = StoreName.TrustedPeople;
        internal static StoreLocation CertStoreLocation = StoreLocation.LocalMachine;

        // Statics initialized from app.config
        internal static string IssuerCertDistinguishedName;

        /// <summary>
        /// Helper function to load Application Settings from config
        /// </summary>
        public static void LoadAppSettings()
        {
            IssuerCertDistinguishedName = ConfigurationManager.AppSettings["issuerCertDistinguishedName"];
            CheckIfLoaded(IssuerCertDistinguishedName);
        }
        /// <summary>
        /// Helper function to check if a required Application Setting has been specified in config.
        /// Throw if some Application Setting has not been specified.
        /// </summary>
        private static void CheckIfLoaded(string s)
        {
            if (String.IsNullOrEmpty(s))
            {
                throw new ConfigurationErrorsException("Required Configuration Element(s) missing at BookStoreService. Please check the service configuration file.");
            }
        }

        private ServiceConstants() { }
    }
}
