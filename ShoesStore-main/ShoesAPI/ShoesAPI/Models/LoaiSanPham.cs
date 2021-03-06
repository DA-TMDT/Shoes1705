using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoesAPI.Models
{
    public class LoaiSanPham
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int product_type_id {get; set;}

        public string name {get; set;}

        public string description {get; set;}

        public int status {get; set;}

        public ICollection<Product> SanPhams {get; set;}

        public LoaiSanPham(){
            this.SanPhams = new HashSet<Product>();
        }
    }
}