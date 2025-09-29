using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace TutorialEntityFramework.Entities
{
    public class Product
    {
        [Key]
        [DisplayName("Id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [DisplayName("Name")]
        [StringLength(150)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [DisplayName("Price")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        public int CategoryId { get; set; }
        [DisplayName("Category")]
        public Category? Category { get; set; }

        [DisplayName("Description")]
        [StringLength(255)]
        public string? Description { get; set; }
    }
}
