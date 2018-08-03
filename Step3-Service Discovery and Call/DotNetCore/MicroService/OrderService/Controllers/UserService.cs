using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Steeltoe.Common.Discovery;

namespace OrderService.Controllers
{

    public class UserService //: IFortuneService
    {
        DiscoveryHttpClientHandler _handler;
        private const string serviceUrl = "http://fortuneService/api/fortunes/random";
        public UserService(IDiscoveryClient client)
        {
            _handler = new DiscoveryHttpClientHandler(client);
        }
        public async Task<string> getAll()
        {
            var client = GetClient();
            return await client.GetStringAsync(serviceUrl+"/getall");
        }
        private HttpClient GetClient()
        {
            var client = new HttpClient(_handler, false);
            return client;
        }
    }
}
