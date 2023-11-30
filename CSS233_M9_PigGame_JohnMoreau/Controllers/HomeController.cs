/*
* John Moreau
* CSS233
* 11/29/2023
*/

using CSS233_M9_PigGame_JohnMoreau.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;

namespace CSS233_M9_PigGame_JohnMoreau.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {

            var game = HttpContext.Session.GetObject<PigGame>("game") ?? new PigGame();






            HttpContext.Session.SetObject("game", game);
            return View();
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}