using WebShopMVC.Models;

namespace WebShopMVC.Extensions
{
    public class CartItem
    {
        public Product Product { get; set; }
        public decimal Quantity { get; set; }

        public decimal getTotal()
        { 
            return Quantity * Product.Price * (1.0m - Product.Discount / 100);
        }
    }
}
