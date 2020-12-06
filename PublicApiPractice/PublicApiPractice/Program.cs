using System;
using System.Net;
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
            // our result from the api, with an await. GetstringAsync is used when our response will be a string in an asynchronous method
            // var data = await httpClient.GetStringAsync(url);
            // getasnyc gives us the repsonse back asynchrrnously, getAsync only accepts the url of the api as its only arguement, dont think it accepts tokens..?
            // using the httpResponseMessage gives us access to the repsonse code and headers (200, 400 etc)
            HttpResponseMessage httpResponse = await httpClient.GetAsync(url);

            if (httpResponse.StatusCode == HttpStatusCode.OK)
            {
                var content = httpResponse.Content;
                var data = await content.ReadAsStringAsync();
                Console.WriteLine(data);
            }
        }
    }
}
