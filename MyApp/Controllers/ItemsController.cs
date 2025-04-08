using Microsoft.AspNetCore.Mvc;
using MyApp.Models;
using System;

namespace MyApp.Controllers
{
    public class ItemsController : Controller
    {
        public IActionResult Overview()
        {
            Random random = new Random();
            HashSet<int> set = new HashSet<int>();
            while (set.Count < 3)
            {
                set.Add(random.Next(1, 10));
            }

            List<int> temp = set.ToList();

            int correctIndex = random.Next(0, temp.Count);

            var item = new Item() { Numbers = temp, CorrectNumber = temp[correctIndex] };
            return View(item);
        }

        [HttpPost]
        public IActionResult Overview(Item model)
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
