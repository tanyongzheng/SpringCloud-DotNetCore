using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace OrderService.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IUserService userService;
        //构造方法来注入实例
        public OrderController(IUserService userService)
        {
            this.userService = userService;
        }

        [Route("getalluser")]
        [HttpGet]
        public async Task<List<User>> getAll()
        {
            List<User> list = await userService.getAll();
            return list;
        }

        [Route("getuserserviceport")]
        [HttpGet]
        public async Task<string> getUserServicePort()
        {
            var port = await userService.getPort();
            return port;
        }

    }
}
