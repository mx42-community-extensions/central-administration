using System;
using System.Resources;
using System.Security.Cryptography.X509Certificates;

namespace CentralAdministration.Contracts.DataContracts
{
    public class Vendor : IDisposable
    {
        public Guid Id { get;  }
        public string Name { get; }

        private ResourceManager resourceManager;

        public Vendor (Guid id, string name, string resourceName)
        {
            Id = id;
            Name = name;
            this.resourceManager = new ResourceManager($"CentralAdministration.Vendors.{resourceName}", typeof(Vendor).Assembly);
        }

        private string logo = null;
        public string GetLogo()
        {
            if (!String.IsNullOrEmpty(logo)) return logo;

            object resource = resourceManager.GetObject("logo.png");
            if (resource is byte[] data)
            {
               return logo = "data:image/png;base64," +Convert.ToBase64String(data);
            }
            return null;
        }

        private Uri registrationUrl = null;
        public Uri GetRegistrationUrl() => registrationUrl ?? (registrationUrl = new Uri(resourceManager.GetString("RegistrationUrl")));

        private Uri extensionsUrl = null;
        public Uri GetExtensionsUrl() => extensionsUrl ?? (extensionsUrl = new Uri(resourceManager.GetString("ExtensionsUrl")));

        private X509Certificate2 publicCertificate = null;
        public X509Certificate2 GetPublicCertificate() => publicCertificate ?? ( new X509Certificate2(resourceManager.GetString("PublicCertificate")));

        public void Dispose()
        {
            if(publicCertificate != null)
                publicCertificate.Dispose();

            if (this.resourceManager != null)
                this.resourceManager.ReleaseAllResources();
        }
    }
}