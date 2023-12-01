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
            // Tried this first, but was causing page refreshes to re-do the button press.
            //var session = new PigGameSession(HttpContext.Session);
            //var game = session.GetGame();

            //switch (button)
            //{
            //    case "Roll":
            //        game.Roll();
            //        break;
            //    case "Hold":
            //        game.Hold();
            //        break;
            //    case "NewGame":
            //        game.ResetGame();
            //        break;
            //    default:
            //        break;
            //}

            //session.SetGame(game);


            // No longer needed since we can use coalescing null operator to check for game object in the index.cshtml
            //if (HttpContext.Session.GetObject<PigGame>("game") == null)
            //{
            //    HttpContext.Session.SetObject("game", new PigGame());
            //}

            return View();
        }

        public IActionResult Roll()
        {
            var session = new PigGameSession(HttpContext.Session);
            session.Roll();
            return RedirectToAction("Index");
        }

        public IActionResult Hold()
        {
            var session = new PigGameSession(HttpContext.Session);
            session.Hold();
            return RedirectToAction("Index");
        }

        public IActionResult NewGame()
        {
            var session = new PigGameSession(HttpContext.Session);
            session.NewGame();

            return RedirectToAction("Index");
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}