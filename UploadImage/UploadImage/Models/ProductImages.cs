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

        [Column("image_1")]
        public string Image1 { get; set; }

        [Column("image_2")]
        public string Image2 { get; set; }

        [Column("image_3")]
        public string Image3 { get; set; }

        [Column("image_4")]
        public string Image4 { get; set; }

        [Required]
        [Column("product_id")]
        [ForeignKey("Product")]
        public string ProductId { get; set; }

        public virtual string Product { get; set; }
    }
}
