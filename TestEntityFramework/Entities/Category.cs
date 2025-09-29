using System.ComponentModel.DataAnnotations;


namespace TutorialEntityFramework.Entities
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        [StringLength(150)]
        public string Name { get; set; } = string.Empty;
        // Navigation property
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
