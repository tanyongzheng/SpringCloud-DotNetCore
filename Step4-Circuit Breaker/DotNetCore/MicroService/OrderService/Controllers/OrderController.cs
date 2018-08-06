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
        private readonly IUserService _userService;

        private readonly UsergetAllCommand _usergetAllCommand;

        private readonly UsergetPortCommand _usergetPortCommand;
        //构造方法来注入实例
        public OrderController(IUserService userService
            ,UsergetAllCommand usergetAllCommand
            ,UsergetPortCommand usergetPortCommand)
        {
            _userService = userService;
            _usergetAllCommand = usergetAllCommand;
            _usergetPortCommand = usergetPortCommand;
        }

        [Route("getalluser")]
        [HttpGet]
        public async Task<List<User>> getAll()
        {
            //List<User> list = await _userService.getAll();
            var list =await _usergetAllCommand.getAll();
            return list;
        }

        [Route("getuserserviceport")]
        [HttpGet]
        public async Task<string> getUserServicePort()
        {
            //var port = await _userService.getPort();
            var port = await _usergetPortCommand.getPort();
            return port;
        }

    }
}
