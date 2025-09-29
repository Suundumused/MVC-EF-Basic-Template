using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace TutorialEntityFramework.ViewModels
{
    public class ProductViewModel 
    {
        [Key]
        [Display(Name = "Id")]
        [Required(ErrorMessage = "Missing entity's ID.")]
        public int Id { get; set; }

        [DisplayName("Name")]
        [Required(ErrorMessage = "Missing entity's name.")]
        [StringLength(150)]
        public string Name { get; set; } = string.Empty;

        [DisplayName("Price")]
        [Required(ErrorMessage = "Missing entity's price.")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [DisplayName("Category")]
        public int CategoryId { get; set; }

        [StringLength(255)]
        public string? Description { get; set; }

        public IEnumerable<SelectListItem>? Categories { get; set; }
    }
}
