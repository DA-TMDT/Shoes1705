using System;
using System.ComponentModel.DataAnnotations;

namespace ShoesAPI.Models
{
    public class NhanVien
    {
        [Key]
        public string user{get; set;}

        public string pass{get; set;}

        public string full_name{get; set;}

        public string phone{get; set;}

        public string mail{get; set;}

        public string address {get; set;}

        public string sex{get; set;}

        public DateTime dateborn{get; set;}

        public int permission_id {get; set;}

        public int status{get; set;}

        public NhanVien()
        {
            status = 1;
        }
    }
}