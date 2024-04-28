using System.ComponentModel;

namespace ProductCrud.Models
{
    public class Product
    {
        [DisplayName("S No")]
        public int Id { get; set; }


        [DisplayName("Product")]
        public string Name { get; set; }


        [DisplayName("Description")]
        public string Description { get; set; }


        [DisplayName("Created")]
        public DateTime CreatedAt { get; set; }
    }
}
