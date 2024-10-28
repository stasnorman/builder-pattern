using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace BuilderPatternAPI.Models
{
    public class ProductSearchRequest
    {
        [Required]
        [StringLength(100)]
        [Description("Категория продукта.")]
        public string Category { get; set; }

        [Description("Минимальная цена продукта.")]
        public decimal MinPrice { get; set; }

        [Description("Максимальная цена продукта.")]
        public decimal MaxPrice { get; set; }
    }

}
