using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;
namespace ShoesAPI.Models
{
    public class HoaDon
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int bill_id{get; set;}      
        public string user_kh {get; set;}

        public string user_nv { get; set;}
      
        public string phone{get; set;}

        public string address {get; set;}

        [DataType(DataType.Date)]
        public DateTime? date_receice{get; set;}
        
        [DataType(DataType.Date)]
        public DateTime? date_order{get; set;}
        public long total { get; set;}

        public int status { get; set;}
    }
}