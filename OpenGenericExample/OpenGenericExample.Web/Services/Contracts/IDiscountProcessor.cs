using OpenGenericExample.Web.Models;
using System.Collections.Generic;

namespace OpenGenericExample.Web.Services.Contracts
{
    public interface IDiscountProcessor
    {
        (double, List<string>) ProcessDiscount(OrderViewModel order);
    }
}
