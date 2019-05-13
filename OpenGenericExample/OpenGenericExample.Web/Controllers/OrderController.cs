using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using OpenGenericExample.Web.Logging;
using OpenGenericExample.Web.Models;
using OpenGenericExample.Web.Services.Contracts;

namespace OpenGenericExample.Web.Controllers
{
    public class OrderController : Controller
    {
        private readonly IDiscountProcessor _discountProcessor;
        private readonly ILogWriter<OrderController> _logWriter;

        public OrderController(IDiscountProcessor discountProcessor, ILogWriter<OrderController> logWriter)
        {
            _discountProcessor = discountProcessor;
            _logWriter = logWriter;
        }

        public IActionResult Index()
        {
            _logWriter.LogInfo("Index method called");
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
                _logWriter.LogWarning("Model is not valid");
                return View(model);
            }
        }

        [HttpGet]
        public IActionResult Checkout(CheckoutViewModel model)
        {
            _logWriter.LogInfo("Checkout called.");
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
