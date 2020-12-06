using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace PublicApiPractice
{
    class Program
    {
        // main method must be async of type Task (bring in threading.task namespace)
        static async Task Main(string[] args)
        {
            // use the httpclientfactory class to create a new instance of httpclient type
            // httpclientfactory is used for creating HttpClient instances to be used in our application
            // must install package (microsoft.aspnet.webapi.client)
            var httpClient = HttpClientFactory.Create();
            // api url saved in a string varibale 
            string url = "https://anapioficeandfire.com/api/characters/583";
            // our result from the api, with an await and getStringAsync
            var data = await httpClient.GetStringAsync(url);

            Console.WriteLine(data);
        }
    }
}
