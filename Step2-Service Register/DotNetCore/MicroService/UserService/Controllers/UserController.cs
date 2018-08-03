using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UserService.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [Route("getall")]
        [HttpGet]
        public List<User> getAll()
        {
            List<User> list = new List<User>();
            var user1 = new User();
            user1.age = 11;
            user1.name = "小新";
            user1.deleted = false;

            var user2 = new User();
            user2.age = 20;
            user2.name = "Mr Lee";
            user2.deleted = true;
            list.Add(user1);
            list.Add(user2);
            return list;
        }

        [HttpGet]
        public string getName()
        {
            return "getName";
        }
    }
}
