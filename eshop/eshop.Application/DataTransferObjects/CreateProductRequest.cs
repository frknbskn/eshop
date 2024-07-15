using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eshop.Application.DataTransferObjects
{
    public class CreateProductRequest
    {
        [Required]
        [MaxLength(150)]
        public string Name { get; set; }
        [DataType(DataType.MultilineText)]
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public double? Rating { get; set; }
        [DataType(DataType.ImageUrl)]
        public string? ImageURL { get; set; } = "https://cdn.dsmcdn.com/ty1018/product/media/images/prod/SPM/PIM/20231019/13/899e8cb7-16a0-3617-bae0-555eacd2e713/1_org.jpg";
        
        public int CategoryId { get; set; }
    }
}
