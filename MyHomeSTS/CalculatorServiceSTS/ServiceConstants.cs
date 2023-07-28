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
        // Issuer name placed into issued tokens
        internal const string SecurityTokenServiceName = "CalculatorService STS";

        // Statics for location of certs
        internal static readonly StoreName CertStoreName = StoreName.TrustedPeople;
        internal static readonly StoreLocation CertStoreLocation = StoreLocation.LocalMachine;

        // Statics initialized from app.config
        internal static string CertDistinguishedName;
        internal static string TargetDistinguishedName;
        internal static string IssuerDistinguishedName;

        /// <summary>
        /// Helper function to load Application Settings from config
        /// </summary>
        public static void LoadAppSettings()
        {
            CertDistinguishedName = ConfigurationManager.AppSettings["certDistinguishedName"];
            CheckIfLoaded(CertDistinguishedName);

            TargetDistinguishedName = ConfigurationManager.AppSettings["targetDistinguishedName"];
            CheckIfLoaded(TargetDistinguishedName);

            IssuerDistinguishedName = ConfigurationManager.AppSettings["issuerDistinguishedName"];
            CheckIfLoaded(IssuerDistinguishedName);
        }

        /// <summary>
        /// Helper function to check if a required Application Setting has been specified in config.
        /// Throw if some Application Setting has not been specified.
        /// </summary>
        private static void CheckIfLoaded(string s)
        {
            if (String.IsNullOrEmpty(s))
            {
                throw new ConfigurationErrorsException("Required Configuration Element(s) missing at BookStoreSTS. Please check the STS configuration file.");
            }
        }

        private ServiceConstants() { }
    }
}
