using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MyApp.Models;

namespace MyApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction("Game");
        }
        public IActionResult Game()
        {
            Random random = new Random();
            HashSet<int> set = new HashSet<int>();
            while (set.Count < 3)
            {
                set.Add(random.Next(1, 10));
            }

            List<int> temp = set.ToList();

            int correctIndex = random.Next(0, temp.Count);

            var game = new Game() { Numbers = temp, CorrectNumber = temp[correctIndex] };
            return View(game);
        }

        [HttpPost]
        public IActionResult Game(Game model)
        {
            if (model.SelectedNumber.HasValue)
            {
                if (model.SelectedNumber == model.CorrectNumber)
                {
                    model.Message = $"Correct!";
                }
                else
                {
                    model.Message = $"Wrong! Number was {model.CorrectNumber}";
                }
            }
            return View(model);
        }
    }
}
