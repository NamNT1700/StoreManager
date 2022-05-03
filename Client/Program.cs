using IdentityModel.Client;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Linq;
using System.Text.Json;
using Newtonsoft.Json.Linq;

namespace Client
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var client = new HttpClient();
            var disco = await client.GetDiscoveryDocumentAsync("http://localhost:5000");
            if (disco.IsError)
            {
                Console.WriteLine(disco.Error);
                return;
            }
            // request token
            var tokenResponse = await client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
            {
                Address = disco.TokenEndpoint,

                ClientId = "ConstruxivViewer",
                ClientSecret = "ConstruxivViewersecret",
                Scope = "API"
            });

            if (tokenResponse.IsError)
            {
                Console.WriteLine(tokenResponse.Error);
                return;
            }

            Console.WriteLine(tokenResponse.Json);
            var apiClient = new HttpClient();
            apiClient.SetBearerToken(tokenResponse.AccessToken);

            var response = await apiClient.GetAsync("http://localhost:5000/api/UserControllers/Login");
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine(response.StatusCode);
            }
            else
            {
                var content = await response.Content.ReadAsStringAsync();
                Console.WriteLine(JArray.Parse(content));
            }
        }
    }
}
