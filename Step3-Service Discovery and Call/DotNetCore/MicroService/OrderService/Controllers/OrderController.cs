using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace OrderService.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrderController
    {
        [Route("getalluser")]
        [HttpGet]
        public List<User> getAll()
        {
            List < User > list= null;
            return list;
        }

    }
}
