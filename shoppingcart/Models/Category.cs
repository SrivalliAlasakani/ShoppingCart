using System.ComponentModel.DataAnnotations;

namespace shoppingcart.Models
{
    public class Category
    {
        [key]
        public int CategoryId { get; set; }
        [Required]
        [MaxLength(60,ErrorMessage ="Length should not be greater than 60")]
        public string Name { get; set; }
        [Range(0, 60,ErrorMessage ="Error message must bebetween 1-59")]
        public int DisplayOrder { get; set; }
    }
}
