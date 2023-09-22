using System;
using System.Collections.Generic;
using Xamarin.Forms;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using Sprint1MobileProject.Utils;
using System.Web;
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

            if(res.StatusCode == HttpStatusCode.Created)
            {
                await DisplayAlert("Sucesso", "Sua ordem foi registrada com sucesso!", "OK");
            } 
            else if(res.StatusCode == HttpStatusCode.BadRequest)
            {
                await DisplayAlert("Erro", "Erro ao enviar ordem! Tente novamente mais tarde.", "OK");
            }
        }
    }
}
