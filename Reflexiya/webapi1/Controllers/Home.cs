using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webapi1.Controllers
{
    [ApiController]
    [Route("api/Home")]
    public class HomeController : Controller
    {
        [HttpGet]
        [Route("rand")]
        public int getRandom()
        {
            var rand = new Random();
            return rand.Next(0, 100);
        }

        [HttpGet]
        [Route("name")]
        [Obsolete]
        public string getName()
        {
            return "U name is LOX";
        }
        [HttpGet]
        [Route("isLox")]
        public bool LoxAmI(string name)
        {
            if (name.ToLower().Contains("lox")) return true;
            else
                return true;
        }
    }
}
