using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MvcSmartStore.Models
{
    public class Smartphone
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Brand is required")]
        public string Brand { get; set; } = null!;

        [Required(ErrorMessage = "Model is required")]
        public string Model { get; set; } = null!;

        [Required(ErrorMessage = "Price is required")]
        [Range(0.01, float.MaxValue, ErrorMessage = "Price must be greater than 0")]
        public float Price { get; set; }

        public string? Selling_platform { get; set; }

        [Range(0, 5, ErrorMessage = "Rating must be between 0 and 5")]
        public float Rating { get; set; }

        [Required(ErrorMessage = "Refresh rate is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Refresh rate must be positive")]
        public int Refresh_rate { get; set; }

        [Required(ErrorMessage = "Screen size is required")]
        [Range(1, float.MaxValue, ErrorMessage = "Screen size must be positive")]
        public float Screen_size { get; set; }

        [Required(ErrorMessage = "RAM is required")]
        [Range(1, int.MaxValue, ErrorMessage = "RAM must be positive")]
        public int Ram { get; set; }

        [Required(ErrorMessage = "Storage is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Storage must be positive")]
        public int Storage { get; set; }

        public string? Processor { get; set; }

        public string? Camera_setup { get; set; }

        public string? imgURL { get; set; }

        public ICollection<Order>? Orders { get; set; }
    }
}
