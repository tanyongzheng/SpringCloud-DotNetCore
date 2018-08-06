using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Steeltoe.CircuitBreaker.Hystrix;
using Steeltoe.Common.Discovery;

namespace OrderService.Controllers
{

    public class UserService : IUserService
    {
        DiscoveryHttpClientHandler _handler;
        private const string serviceUrl = "http://userservice/user";
        public UserService(IDiscoveryClient client)
        {
            _handler = new DiscoveryHttpClientHandler(client);
        }

        public async Task<List<User>> getAll()
        {
            var client = GetClient();
            var json= await client.GetStringAsync(serviceUrl+"/getall");
            List<User> list= JsonConvert.DeserializeObject<List<User>>(json);
            return list;
        }

        public async Task<string> getPort()
        {
            var client = GetClient();
            return await client.GetStringAsync(serviceUrl + "/getport");
        }

        private HttpClient GetClient()
        {
            var client = new HttpClient(_handler, false);
            return client;
        }
        
    }
}
