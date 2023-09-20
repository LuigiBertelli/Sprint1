using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using System.Net.Http;
using System.Net.Http.Json;
using System.Configuration;
using Sprint1MobileProject.Utils;
using System.Web;
using System.Net.Http.Headers;
using System.Text.Json.Serialization;
using Xamarin.Essentials;

namespace Sprint1MobileProject
{
    public partial class MainPage : ContentPage
    {
        #if DEBUG
            private HttpClient client = new HttpClient(DependencyService.Get<IHttpClientHandlerService>().GetInsecureHandler());
        #else
            private HttpClient client = new HttpClient();
        #endif

        public MainPage()
        {
            InitializeComponent();
        }

        public async void OnBtnOrderClicked(object sender, EventArgs e)
        {
            var uri = $"https://{(DeviceInfo.Platform == DevicePlatform.Android ? "10.0.2.2" : "localhost")}:7226/order";
            var fixDict = new Dictionary<int, string>()
            {
                { 35, "D" },
                { 49, "CLIENT1" },
                { 56, "EXECUTOR" },
                { 1, "ACC1" },
                { 34, "3" },
                { 52, DateTime.UtcNow.ToString() },
                { 11, "1288152766"},
                { 21, "1" },
                { 55, FixUtil.GenerateRandomTag55() },
                { 54, "1" },
                { 60, DateTime.UtcNow.ToString() },
                { 40, "2" },
                { 44, FixUtil.GenerateRandomTag44().ToString() },
                { 38, "1000" }
            };


            var fixTxt = HttpUtility.UrlEncode(FixUtil.GenerateFIX(fixDict));
            var res = await client.PostAsJsonAsync(uri, new { code = fixTxt});
        }
    }
}
