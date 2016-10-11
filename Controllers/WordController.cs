using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace randomWordGenerator.Controllers
{
    public class WordController : Controller
    {
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Word()
        {
            if(HttpContext.Session.GetInt32("count") == null)
            { 
                HttpContext.Session.SetInt32("count", 0);
                HttpContext.Session.SetString("word", "");
            }
            ViewBag.count = HttpContext.Session.GetInt32("count");
            ViewBag.word = HttpContext.Session.GetString("word");
            return View("Word");
        }

        [HttpPost]
        [RouteAttribute("/generate")]
        public IActionResult Generate()
        {
            string myString = "";
            Random random = new Random();
            char ch ;
            for(int i=0; i<10; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65))) ;
                myString += ch;
                Console.WriteLine("string" + myString);
            }
             HttpContext.Session.SetInt32("count", (int) HttpContext.Session.GetInt32("count") + 1);
             HttpContext.Session.SetString("word", myString);
            return RedirectToAction("Word"); 
        }
        [HttpPost]
        [RouteAttribute("/reset")]
        public IActionResult Reset()
        {
            HttpContext.Session.SetInt32("count", 0);
            HttpContext.Session.SetString("word", "");
            return RedirectToAction("Word"); 
        }
    }
}
