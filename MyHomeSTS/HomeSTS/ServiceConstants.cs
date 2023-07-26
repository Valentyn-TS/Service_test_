using System;
using System.Configuration;
using System.Security.Cryptography.X509Certificates;


namespace My_STS
{
    class ServiceConstants
    {
        // Issuer name placed into issued tokens
        internal const string StsName = "Home STS";

        // Statics for location of certs
        internal static StoreName CertStoreName = StoreName.TrustedPeople;
        internal static StoreLocation CertStoreLocation = StoreLocation.LocalMachine;

        // Statics initialized from app.config
        internal static string CertDistinguishedName;
        internal static string TargetDistinguishedName;
        internal static double PurchaseLimit;

        #region Helper functions to load app settings from config
        /// <summary>
        /// Helper function to load Application Settings from config
        /// </summary>
        public static void LoadAppSettings()
        {
            CertDistinguishedName = ConfigurationManager.AppSettings["certDistinguishedName"];
            CheckIfLoaded(CertDistinguishedName);

            TargetDistinguishedName = ConfigurationManager.AppSettings["targetDistinguishedName"];
            CheckIfLoaded(TargetDistinguishedName);

            string purchaseLimitString = ConfigurationManager.AppSettings["purchaseLimit"];
            CheckIfLoaded(purchaseLimitString);
            PurchaseLimit = Double.Parse(purchaseLimitString);
        }

        /// <summary>
        /// Helper function to check if a required Application Setting has been specified in config.
        /// Throw if some Application Setting has not been specified.
        /// </summary>
        private static void CheckIfLoaded(string s)
        {
            if (String.IsNullOrEmpty(s))
            {
                throw new ConfigurationErrorsException("Required Configuration Element(s) missing at HomeSTS. Please check the STS configuration file.");
            }
        }

        #endregion

        private ServiceConstants() { }
    }
}
