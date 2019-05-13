using OpenGenericExample.Web.Models;
using OpenGenericExample.Web.Services.Contracts;

namespace OpenGenericExample.Web.Services
{
    public class ThreeOrModeDiscount : IDiscount
    {
        public string Description => "3 Items or more gets 3% discount";

        public double CalculateDiscount(OrderViewModel order)
        {
            if (order.Quantity >= 3)
            {
                return (order.Price * order.Quantity) * 0.03;
            }
            return 0;
        }
    }
}
