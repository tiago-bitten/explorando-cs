using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UploadImage.Models
{

    [Table("tb_product")]
    public class Product
    {
        [Key]
        [Required]
        [Column("id")]
        public string Id { get; set; }

        [Required]
        [Column("name")]
        public string Name { get; set; }

        [Required]
        [Column("price")]
        public double Price { get; set; }

        [Required]
        [Column("purchase_price")]
        public double PurchasePrice { get; set; }

        public virtual ICollection<ProductImages> ProductImages { get; set; }
    }
}
