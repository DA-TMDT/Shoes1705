using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ShoesAPI.DTOs;
using ShoesAPI.DTOs.Admin.Customer;
using ShoesAPI.Services;

namespace ShoesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerService KHservice;
        public CustomerController(CustomerService KHservice){
            this.KHservice = KHservice;
        }
        [HttpGet]
        public IEnumerable<CustomerDto> GetKHDtos()
        {
            return KHservice.KhachHang_GetAll();
        }

        [HttpGet("{user}")]
        public CustomerDto GetKHDto(string user)
        {
            return KHservice.KhachHang_GetByUser(user);
        }

        [HttpPost]
        public ActionResult<CustomerDto> AddKHDto(CustomerDto p)
        {
            KHservice.KhachHang_Add(p);

            return CreatedAtAction(nameof(GetKHDto), new { user = p.user }, p);
        }

        [HttpPut]
        public void UpdateKHDto([FromBody] CustomerDto p)
        {
            KHservice.KhachHang_Update(p);
        }

        [HttpDelete("{user}")]
        public void DeleteKHDto(string user)
        {
            KHservice.KhachHang_Remove(user);
        }

        // Các phần cho các trang đặc biệt
        [HttpPost("register")]
        public ActionResult<CustomerDto> AddKHDto_Register(CustomerDto p)
        {
            KHservice.KhachHang_Add(p);

            // Ẩn thông tin khách hàng
            p.pass = "";
            p.phone = "";
            p.address = "";
            p.mail = "";
            p.address = "";
            p.dateborn = new DateTime();
            p.status = -1;

            return CreatedAtAction(nameof(GetKHDto), new { user = p.user }, p);
        }

        [HttpPost("login")]
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
            return CreatedAtAction(nameof(GetKHDto), new { user = kh.user }, kh);
        }

        // Tìm kiếm bên admin khách hàng
        [HttpPost("manager_khsearch")]
        public IEnumerable<CustomerDto> TimKiem(Customer_SearchDto q){
            if(String.IsNullOrEmpty(q.input)){
                q.input = "";
            }
            return KHservice.KhachHang_AdminTimKiem(q.type, q.input);
        }
    }
}