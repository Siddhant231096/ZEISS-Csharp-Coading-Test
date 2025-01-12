using System.ComponentModel.DataAnnotations;

namespace ProductApi.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }  // Auto-generated unique product ID
        public int SKUNumber {get; set;}
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int StockAvailable { get; set; }
    }
}
