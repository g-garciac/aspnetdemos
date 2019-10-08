using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using MvcPocs.Models;

namespace MvcPocs.Controllers
{
    public class BindingsController : Controller
    {
        public static List<BindingsDemoVm> Data = new List<BindingsDemoVm>();
        public IActionResult Index()
        {
            return View(Data);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(BindingsDemoVm model)
        {
            if (UnaReglaDeNegocioNoSeCumple(model))
            {
                ModelState.AddModelError("RN-001", "No se cumplió la regla xxxxxx");
            }
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            try
            {
                Data.Add(model);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("EX-001", "Un mensaje error que no revele información sensible, pero que esté de acuerdo a la excepción que ocurrió.");
                return View();
            }
        }

        private bool UnaReglaDeNegocioNoSeCumple(BindingsDemoVm model)
        {
            return model.DayOfWeek == Models.DayOfWeek.Sunday && model.Name == "Polo";
        }
    }
}