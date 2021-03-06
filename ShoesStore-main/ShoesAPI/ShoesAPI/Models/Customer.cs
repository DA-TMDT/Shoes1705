using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoesAPI.Models
{
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string user{get; set;}
        public string pass{get; set;}
        public string full_name{get; set;}
        public string phone{get; set;}
        public string mail{get; set;}
        public string address {get; set;}
        public string sex{get; set;}
        public DateTime dateborn{get; set;}
        public int status{get; set;}

        // public ICollection<HoaDon> hoadons {get; set;}

        public Customer()
        {
            status = 1;
            // this.hoadons = new HashSet<HoaDon>();
        }
    }
}