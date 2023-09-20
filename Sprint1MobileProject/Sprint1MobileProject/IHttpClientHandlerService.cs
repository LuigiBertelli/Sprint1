using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Sprint1MobileProject
{
    public interface IHttpClientHandlerService
    {
        HttpClientHandler GetInsecureHandler();
    }
}
