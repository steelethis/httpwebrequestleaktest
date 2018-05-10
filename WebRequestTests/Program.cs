using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WebRequestTests
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Press any key to start sending requests.");
            Console.ReadKey();

            string url = "http://10.100.5.98:5001/api/values/5";

            while (true)
            {
                new Thread(async () =>
                {
                    WebRequest request = WebRequest.Create(url);

                    request.Timeout = 10000;

                    try
                    {
                        using (WebResponse response = await request.GetResponseAsync())
                        {
                            Console.WriteLine($"Response received: {response.ResponseUri}");
                            response.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Exception {ex.Message}\n{ex.StackTrace}");
                    }
                }).Start();

            }
        }
    }
}
