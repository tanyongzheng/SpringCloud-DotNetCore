using System;
using System.Net.Http;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string userServiceUrl = "http://localhost:5551/userservice/user/";//通过网关地址来调用服务
            var client = new HttpClient { BaseAddress = new Uri(userServiceUrl) };
            HttpResponseMessage response = client.GetAsync("getall").Result;
            string responseStr = response.Content.ReadAsStringAsync().Result;
            Console.WriteLine(responseStr);
            Console.ReadKey();
        }
    }
}
