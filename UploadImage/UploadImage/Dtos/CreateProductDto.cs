using System.ComponentModel.DataAnnotations;

namespace UploadImage.Dtos
{
    public class CreateProductDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public int Price { get; set; }

        [Required]
        public int PurchasePrice { get; set; }
    }
}
