using System;
using System.Collections.Generic;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using ShoesAPI.DTOs;
using ShoesAPI.DTOs.Admin.SanPham;
using ShoesAPI.Models;
using ShoesAPI.Services;

namespace ShoesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductService ProductService;
        private readonly LoaiSanPhamService LSPService;
        public ProductController(ProductService ProductService, LoaiSanPhamService LSPService) {
            this.ProductService = ProductService;
            this.LSPService = LSPService;
        }

        [HttpGet]
        public IEnumerable<ProductDto> GetSPDtos() {
            return this.ProductService.SanPham_GetAll();
        }

        [HttpGet("{id}")]
        public ProductDto GetSPDto(int id) {
            return this.ProductService.SanPham_GetById(id);
        }

        [HttpPost]
        public ActionResult<ProductDto> AddSPDto(ProductDto SP) {
            this.ProductService.SanPham_Add(SP);

            return CreatedAtAction(nameof(GetSPDto), new { id = SP.product_id }, SP);
        }

        [HttpPut]
        public void UpdateSPDto([FromBody] ProductDto SP) {
            ProductService.SanPham_Update(SP);
        }

        [HttpDelete("{id}")]
        public void DeleteSPDto(int id) {
            ProductService.SanPham_Remove(id);
        }

        // =============================== Shop ==============================
        // Load bên Shop
        [HttpPost("shop")]
        public ActionResult<IndexViewShopModel> SanPham_Filter(DataShopLoad data) {
            decimal pricemax;
            string NameType;
            int count;
            if(!string.IsNullOrEmpty(data.Type)){
                NameType = LSPService.LoaiSanPham_GetById(int.Parse(data.Type)).name;
                data.qSearch = null;
            }
            else{
                NameType = null;
            }

            var Products = ProductService.SanPham_Filter(data.Type, data.qSearch, data.price, data.sort, data.pageIndex, Constants.pageSize, out count, out pricemax);
            var ListSP = new PaginatedList<ProductDto>(Products, count, data.pageIndex, Constants.pageSize);
            // Console.WriteLine(ListSP.TotalPages);
            var indexVSM = new IndexViewShopModel()
            {
                ListSP = ListSP,
                Type = data.Type,
                NameType = NameType,
                qSearch = data.qSearch,
                sort = data.sort,
                pricemax = pricemax,
                price = data.price,
                pageSize = Constants.pageSize,
                count = count,
                Range = Constants.Range,
                pageIndex = data.pageIndex,
                TotalPages = ListSP.TotalPages
            };
            return indexVSM;
        }

        // ============================== Index ========================
        [HttpGet("home-spbanchay")]
        public IEnumerable<ProductDto> SPBanChay() {
            return this.ProductService.TenSPChay();
        }

        [HttpGet("home-sphot")]
        public IEnumerable<ProductDto> SPHot() {
            return this.ProductService.TenSPNoi();
        }

        // ============================== Admin - SanPham ================================
        // Tìm kiếm bên admin sản phẩm
        [HttpPost("manager_spsearch")]
        public IEnumerable<ProductDto> TimKiem(SP_SearchDto q){
            if(String.IsNullOrEmpty(q.input)){
                q.input = "";
            }
            return ProductService.SanPhams_AdminTimKiem(q.type, q.input);
        }

        // Khóa trạng thái danh sách sản phẩm theo product_type_id
        [HttpPost("lock_listsp")]
        public void Lock_ListSP(SP_LSP_Status p) {
            this.ProductService.SanPham_Update_Status_By_Product_type_id(p.product_type_id, p.status);
        }
    }
}