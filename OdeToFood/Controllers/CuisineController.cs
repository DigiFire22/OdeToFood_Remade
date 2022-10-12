using Microsoft.AspNetCore.Mvc;
using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OdeToFood.filters;
using System.Text.Encodings.Web;

namespace OdeToFood.Controllers
{
    //[Log]
    public class CuisineController : Controller
    {
        [HttpPost]
        public IActionResult Search(string name = "unknown")
        {
            throw new Exception("Something terrible has happend!");
        }
        //public IActionResult Search(string name = "unknown")
        //{
        //    var message = HtmlEncoder.Default.Encode(name);
        //    throw new Exception("Something terrible happend:(");
        //    return Content(message);
        //}
    }
}
