using System;
using Microsoft.AspNetCore.Mvc;
using asp.net_laboratorna10_shchedrov.Models;

namespace asp.net_laboratorna10_shchedrov.Controllers
{
    public class ConsultationController : Controller
    {
        public IActionResult Index()
        {
            return View(new ConsultationViewModel());
        }

        [HttpPost]
        public IActionResult Index(ConsultationViewModel model)
        {
            if (model.ConsultationDate.HasValue &&
                (model.ConsultationDate.Value <= DateTime.Today ||
                model.ConsultationDate.Value.DayOfWeek == DayOfWeek.Saturday ||
                model.ConsultationDate.Value.DayOfWeek == DayOfWeek.Sunday))
            {
                ModelState.AddModelError("ConsultationDate", "The date must be in the future and cannot fall on a weekend.");
            }

            if (model.Product == "Basics" && model.ConsultationDate.HasValue &&
                model.ConsultationDate.Value.DayOfWeek == DayOfWeek.Monday)
            {
                ModelState.AddModelError("ConsultationDate", "Consultations for 'Basics' cannot be held on Mondays.");
            }

            if (ModelState.IsValid)
            {
                return RedirectToAction("Success");
            }

            return View(model);
        }

        public IActionResult Success()
        {
            return View();
        }
    }
}