namespace Grocery_Store.Web.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
        public double Price { get; set; }
        public int AisleId { get; set; }
    }
}