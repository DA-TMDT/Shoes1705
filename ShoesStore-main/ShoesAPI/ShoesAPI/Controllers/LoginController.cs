
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ShoesAPI.DTOs;
using ShoesAPI.Services;

namespace ShoesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly CustomerService KHservice;
        public LoginController(CustomerService KHservice){
            this.KHservice = KHservice;
        }

        [HttpGet]
        public String Index()
        {
            return "";
        }
        
        [HttpGet("{user}")]
        public CustomerDto GetKhachHangDto(string user)
        {
            return KHservice.KhachHang_GetByUser(user);
        }

        [HttpPost]
        public ActionResult<TaiKhoanDto> Login(TaiKhoanDto p)
        {
            CustomerDto kh = KHservice.KhachHang_GetByUser(p.user);
            if(kh == null) {
                return null;
            }

            if(kh.pass != p.password) {
                return null;
            }
            // Ẩn thông tin khách hàng
            kh.pass = "";
            kh.phone = "";
            kh.address = "";
            kh.mail = "";
            kh.address = "";
            kh.dateborn = new DateTime();
            kh.status = -1;
            return CreatedAtAction(nameof(GetKhachHangDto), new { user = kh.user }, kh);
        }
    }
}