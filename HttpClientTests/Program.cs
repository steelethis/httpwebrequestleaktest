using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HttpClientTests
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Press any key to start sending requests.");
            Console.ReadKey();

            HttpClient client = new HttpClient();
            client.Timeout = TimeSpan.FromSeconds(10);

            string url = "http://10.100.5.98:5001/api/values/5";

            while (true)
            {
                new Thread(async () =>
                {
                    HttpRequestMessage msg = new HttpRequestMessage(HttpMethod.Get, new Uri(url));
                    try
                    {
                        var result = await client.SendAsync(msg).ConfigureAwait(false);
                        Console.WriteLine($"Response received: {result.StatusCode}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"{ex}\n{ex.Message}\n{ex.StackTrace}");
                    }
                }).Start();

            }
        }
    }
}
