using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eshop.Entities
{
    //[Table(name:"Ürünler")]
    public class Product
    {
        [Required]
        [MaxLength(150)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public double? Rating { get; set; }
        public string ImageURL { get; set; } = "https://cdn.dsmcdn.com/ty1018/product/media/images/prod/SPM/PIM/20231019/13/899e8cb7-16a0-3617-bae0-555eacd2e713/1_org.jpg";
        public Category Category { get; set; }
        public int CategoryId { get; set; }

    }
}
