using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace CheatPads.Clients.Console.Services
{

    public static class ApiService
    {
        public static JObject GetProduct(string sku)
        {
            return HttpGetObject(Settings.ProductsEndpoint + "/" + sku);
        }

        public static JArray GetProducts()
        {
            return HttpGetArray(Settings.ProductsEndpoint);
        }

        public static JArray GetProductsByCategory(string categoryName)
        {
            return HttpGetArray(Settings.ProductsEndpoint + "/cat/" + categoryName);
        }

        public static JArray GetCategories()
        {
            return HttpGetArray(Settings.CategoriesEndpoint);
        }

        public static JArray GetColors()
        {
            return HttpGetArray(Settings.ColorsEndpoint, setToken: true);
        }

        public static JObject GetColor(string id)
        {
            return HttpGetObject(Settings.ColorsEndpoint + "/" + id, setToken: true);
        }

        public static string CreateColor(string name, string hex)
        {
            return HttpPost(Settings.ColorsEndpoint, new { Name = name, Hex = hex }, setToken: true);
        }

        public static JObject GetUserPrinciple()
        {
            return HttpGetObject(Settings.UsersEndpoint + "/current", setToken: true);
        }

        public static JArray GetUsers()
        {
            return HttpGetArray(Settings.UsersEndpoint, setToken: true);
        }

        private static JArray HttpGetArray(string uri, bool setToken = false)
        {
            var client = new HttpClient();

            if (setToken)
            {
                client.SetBearerToken(TokenService.CurrentTokenData?.AccessToken);
            }
            string response = client.GetStringAsync(uri).Result;

            return JArray.Parse(response);
        }

        private static JObject HttpGetObject(string uri, bool setToken = false)
        {
            var client = new HttpClient();

            if (setToken)
            {
                client.SetBearerToken(TokenService.CurrentTokenData?.AccessToken);
            }
            string response = client.GetStringAsync(uri).Result;

            return JObject.Parse(response);
        }

        private static string HttpPost(string uri, dynamic data, bool setToken = false)
        {
            var client = new HttpClient();
            var content = new StringContent(
                Newtonsoft.Json.JsonConvert.SerializeObject(data),
                System.Text.Encoding.UTF8,
                "application/json"
            );

            if (setToken)
            {
                client.SetBearerToken(TokenService.CurrentTokenData?.AccessToken);
            }
          
            HttpResponseMessage response = client.PostAsync(uri, content).Result;

            return response.ToString();
        }

    }
}
