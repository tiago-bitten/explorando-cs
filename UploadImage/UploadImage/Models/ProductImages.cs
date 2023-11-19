using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UploadImage.Models
{
    [Table("tb_product_images")]
    public class ProductImages
    {
        [Key]
        [Required]
        [Column("id")]
        public string Id { get; set; }

        [Required]
        [Column("name")]
        public string Name { get; set; }

        [Required]
        [Column("key")]
        public string Key { get; set; }

        [Required]
        [Column("product_id")]
        [ForeignKey("Product")]
        public string ProductId { get; set; }

        public virtual Product Product { get; set; }
    }
}
