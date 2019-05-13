using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OpenGenericExample.Web.Models;
using OpenGenericExample.Web.Services.Contracts;

namespace OpenGenericExample.Web.Controllers
{
    public class OrderController : Controller
    {
        private readonly IDiscountProcessor _discountProcessor;

        public OrderController(IDiscountProcessor discountProcessor)
        {
            _discountProcessor = discountProcessor;
        }

        public IActionResult Index()
        {
            var vm = new OrderViewModel();
            return View(vm);
        }

        [HttpPost]
        public IActionResult Index(OrderViewModel model)
        {
            if (ModelState.IsValid)
            {
                var discounts = _discountProcessor.ProcessDiscount(model);
                var checkoutViewModel = new CheckoutViewModel(model, discounts);
                return RedirectToAction("Checkout", checkoutViewModel);
            }
            else
            {
                return View(model);
            }
        }

        [HttpGet]
        public IActionResult Checkout(CheckoutViewModel model)
        {
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
