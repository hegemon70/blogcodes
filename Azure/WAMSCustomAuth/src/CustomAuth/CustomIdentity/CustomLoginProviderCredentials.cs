using Microsoft.WindowsAzure.Mobile.Service.Security;

namespace CustomAuth.CustomIdentity
{
    public class CustomLoginProviderCredentials : ProviderCredentials
    {
        public CustomLoginProviderCredentials()
            : base(CustomLoginProvider.ProviderName)
        {
        }
    }
}