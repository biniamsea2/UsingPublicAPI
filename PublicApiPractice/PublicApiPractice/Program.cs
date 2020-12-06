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
                //Console.WriteLine(await httpResponse.Content.ReadAsStringAsync());
                
                // line above is a one liner for the 3 lines below:
                var content = httpResponse.Content;

                // need to change ReadAsStringAsync to ReadAsAsync of the type of class you want when getting data 
                // the way you want it from the api
                var data = await content.ReadAsAsync<Data>();
                Console.WriteLine(data);
            }
            else
            {
                Console.WriteLine("Couldn't get data.");
            }
        }
        // created a class based on properties (info) I want from the api
        class Data
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public string Gender { get; set; }
            public string Culture { get; set; }
            public string Born { get; set; }

            // need to override the ToString method to print the way we want it to
            public override string ToString()
            {
                return $"My name is {Name}, a {Gender}, of {Culture}, born {Born}";
            }
        }
    }
}