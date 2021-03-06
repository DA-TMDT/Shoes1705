using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ShoesAPI.DTOs;
using ShoesAPI.Services;

namespace ShoesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ProductService SPService; 
        public CartController(ProductService SPService) {
            this.SPService = SPService;
        }

        [HttpGet("{DonHang}")]
        public IEnumerable<ProductDto> LoadSPForCart(string DonHang) {
            var sps = SPService.SanPham_ListCart(DonHang);
            return sps;
        }

        // [HttpPost("change")]
        // public ActionResult<DonHangDto> changeSPDto(DonHangDto DH) {
        //     DH.changeSoluongSP(DH.product_id, DH.soluong);

        //     return DH;
        // }

        // [HttpPost("subtract")]
        // public ActionResult<DonHangDto> subtractSPDto(DonHangDto DH) {
        //     DH.subtractOneSP(DH.product_id);

        //     return DH;
        // }

        // [HttpPost("remove")]
        // public ActionResult<DonHangDto> removeSPDto(DonHangDto DH) {
        //     DH.removeSP(DH.product_id);

        //     return DH;
        // }
    }
}