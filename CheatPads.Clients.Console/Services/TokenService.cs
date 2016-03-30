using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Text;
using Newtonsoft.Json.Linq;
using IdentityModel;
using IdentityModel.Client;
using IdentityModel.Extensions;

namespace CheatPads.Clients.Console.Services
{
    public static class TokenService
    {
        public static TokenData CurrentTokenData { get; set; }

        public static TokenData ObtainToken()
        {
            var client = new TokenClient(Settings.TokenEndpoint, Settings.ClientId, Settings.ClientSecret, AuthenticationStyle.PostValues);
            var response = client.RequestClientCredentialsAsync(Settings.ClientScope).Result;

            CurrentTokenData = new TokenData(response);

            return CurrentTokenData;
        }

        public static void PrintTokenData()
        {
            if (CurrentTokenData == null)
            {
                "Token data is null. Obtain an access token before calling this command.".ConsoleRed();
            }
            else if (CurrentTokenData.IsValid)
            {
                "TOKEN HEADER:".ConsoleGreen();
                System.Console.WriteLine();
                System.Console.WriteLine(CurrentTokenData.Header);
                System.Console.WriteLine();

                "TOKEN CLAIMS:".ConsoleGreen();
                System.Console.WriteLine();
                System.Console.WriteLine(CurrentTokenData.Claims);
            }
            else
            {
                String.Format("ERROR {0}", CurrentTokenData.ErrorCode.ToString()).ConsoleRed();
                System.Console.WriteLine();

                CurrentTokenData.ErrorReason.ConsoleRed();
                System.Console.WriteLine();
            }
        }
    }

    public class TokenData
    {
        public bool IsValid { get; set; }

        public HttpStatusCode ErrorCode { get; set; }

        public string ErrorReason { get; set; }

        public TokenResponse TokenResponse { get; set; }

        public Dictionary<string, object> Header { get; set; }

        public Dictionary<string, object> Claims { get; set; }

        public string AccessToken { get; set; }

        public TokenData(TokenResponse response)
        {
            IsValid = !response.IsError;

            if (IsValid)
            {
                if (response.AccessToken.Contains("."))
                {
                    var parts = response.AccessToken.Split('.');
                    var header = parts[0];
                    var claims = parts[1];

                    Header = Base64JsonToDictionary(parts[0]);
                    Claims = Base64JsonToDictionary(parts[1]);
                    AccessToken = response.AccessToken;
                }
            }
            else
            {
                if (response.IsHttpError)
                {
                    ErrorCode = response.HttpErrorStatusCode;
                    ErrorReason = response.HttpErrorReason;
                }
                else
                {
                    ErrorReason = response.Json.ToString();
                }
            }
        }
    
        private Dictionary<string, object> Base64JsonToDictionary(string base64Json)
        {
            var json = Encoding.UTF8.GetString(Base64Url.Decode(base64Json));
            var jObj = JObject.Parse(json);

            return jObj.ToObject<Dictionary<string, object>>();
        }
    }
}
