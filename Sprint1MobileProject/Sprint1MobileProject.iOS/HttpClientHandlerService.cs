using System.Net.Http;
using Xamarin.Forms;
using Sprint1MobileProject.iOS;

[assembly: Dependency(typeof(HttpClientHandlerService))]
namespace Sprint1MobileProject.iOS
{
    public class HttpClientHandlerService : IHttpClientHandlerService
    {
        public HttpClientHandler GetInsecureHandler()
        {
            var handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) =>
            {
                if (cert.Issuer.Equals("CN=localhost"))
                    return true;
                return errors == System.Net.Security.SslPolicyErrors.None;
            };
            return handler;
        }
    }
}