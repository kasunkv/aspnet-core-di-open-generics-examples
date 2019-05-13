using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OpenGenericExample.Web.Models
{
    public class CheckoutViewModel
    {
        [Display(Name = "Item")]
        public string ItemName { get; set; }
        public int Quantity { get; set; }
        public double Discount { get; set; }
        public double SubTotal { get; set; }
        public double Total { get; set; }
        public  List<string> AppliedDiscounts { get; set; }

        public CheckoutViewModel(OrderViewModel order, (double, List<string>) discountDetails)
        {
            ItemName = order.ItemName;
            Quantity = order.Quantity;
            Discount = discountDetails.Item1;
            AppliedDiscounts = discountDetails.Item2;
            SubTotal = order.Price * order.Quantity;
            Total = SubTotal - Discount;
        }

        public CheckoutViewModel() {}
    }
}
