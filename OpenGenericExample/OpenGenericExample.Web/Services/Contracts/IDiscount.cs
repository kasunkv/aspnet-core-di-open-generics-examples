using OpenGenericExample.Web.Models;

namespace OpenGenericExample.Web.Services.Contracts
{
    public interface IDiscount
    {
        string Description { get; }
        double CalculateDiscount(OrderViewModel order);
    }
}
