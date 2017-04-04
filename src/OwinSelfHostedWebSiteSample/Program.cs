using System;
using System.Diagnostics;
using System.Net.Http;
using Microsoft.Owin.Hosting;

namespace OwinSelfHostedWebSiteSample
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var baseUrl = "http://localhost:4000";

            // Start OWIN host
            using (WebApp.Start<Startup>(new StartOptions(baseUrl)))
            {
                // Create HttpCient and make a request to api/values
                HttpClient client = new HttpClient();
                //client.BaseAddress = new Uri(baseUrl);
                
                var response = client.GetAsync(baseUrl+"/index.html").Result;
                if (response != null)
                {
                    Console.WriteLine("Information from service: {0}", "stackoverflow sample page"); //response.Content.ReadAsStringAsync().Result);
                }
                else
                {
                    Console.WriteLine("ERROR: Impossible to connect to service");
                }
                // Launch the browser
                Console.WriteLine();
                Process.Start(baseUrl);
                Console.WriteLine("Press ENTER to stop the server and close app...");
                Console.ReadLine(); // Keeps the host from disposing immediately
            }
        }
    }
}
