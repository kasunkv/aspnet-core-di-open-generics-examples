using OpenGenericExample.Web.Logging;
using OpenGenericExample.Web.Models;
using OpenGenericExample.Web.Services.Contracts;
using System.Collections.Generic;

namespace OpenGenericExample.Web.Services
{
    public class OrderDiscountProcessor : IDiscountProcessor
    {
        private readonly IEnumerable<IDiscount> _discounts;
        private readonly ILogWriter<OrderDiscountProcessor> _logWriter;

        public OrderDiscountProcessor(IEnumerable<IDiscount> discounts, ILogWriter<OrderDiscountProcessor> logWriter)
        {
            _discounts = discounts;
            _logWriter = logWriter;
        }

        public (double, List<string>) ProcessDiscount(OrderViewModel order)
        {
            var discountDiscroptoons = new List<string>();
            var totalDiscount = 0.0;

            foreach (var discount in _discounts)
            {

                var addedDiscount = discount.CalculateDiscount(order);
                if (addedDiscount > 0)
                {
                    discountDiscroptoons.Add(discount.Description);
                }
                totalDiscount += addedDiscount;
            }

            _logWriter.LogInfo($"Total discount of ${totalDiscount} is given");
            return (totalDiscount, discountDiscroptoons);
        }
    }
}
