using System.Collections.Generic;
using ShoesAPI.DTOs;
using ShoesAPI.Interfaces;
using ShoesAPI.Mappings;

namespace ShoesAPI.Services
{
    public class ProductService
    {
        private readonly IProductEFContext SPcontext;
        public ProductService(IProductEFContext SPcontext){
            this.SPcontext = SPcontext;
        }
        public IEnumerable<ProductDto> SanPham_GetAll(){
            var sps = SPcontext.SanPham_GetAll();
            return sps.MappingSanPhamDtos();
        }

        public ProductDto SanPham_GetById(int id){
            var sp = SPcontext.SanPham_GetById(id);
            if(sp == null) return null;
            return sp.MappingSanPhamDto();
        }

        public void SanPham_Add(ProductDto SPdto){
            var sp = SPdto.MappingSanPham();
            SPcontext.SanPham_Add(sp);
        }

        public void SanPham_Update(ProductDto SPdto){
            var sp = SPcontext.SanPham_GetById(SPdto.product_id);
            if(sp == null) return;
            SPdto.MappingSanPham(sp);
            SPcontext.SanPham_Update(sp);
        }

        public void SanPham_Remove(int product_id){
            var sp = SPcontext.SanPham_GetById(product_id);
            if(sp == null) return;
            SPcontext.SanPham_Remove(sp);
        }

        public void SanPham_RemoveBy_Product_Type_Id(int product_type_id)
        {
            SPcontext.SanPham_RemoveBy_Product_Type_Id(product_type_id);
        }

        public IEnumerable<ProductDto> SanPham_Shop_GetAll(){
            var sps = SPcontext.SanPham_Shop_GetAll();
            return sps.MappingSanPhamDtos();
        }

        public IEnumerable<ProductDto> SanPham_ListCart(string list) {
            var sps = SPcontext.SanPham_ListCart(list);
            return sps.MappingSanPhamDtos();        }

        public IEnumerable<ProductDto> SanPham_Filter(string Type, string qSearch, string price, string sort, int pageIndex, int pageSize, out int count, out decimal pricemax) {
            var sps = SPcontext.SanPham_Filter(Type, qSearch, price, sort, pageIndex, pageSize, out count, out pricemax);
            return sps.MappingSanPhamDtos();
        }
        public IEnumerable<ProductDto> TenSPChay(){
            var sps = SPcontext.TenSPChay();
            return sps.MappingSanPhamDtos();
        }

        public IEnumerable<ProductDto> TenSPNoi(){
            var sps = SPcontext.TenSPNoi();
            return sps.MappingSanPhamDtos();
        }
        public IEnumerable<ProductDto> SanPhams_AdminTimKiem(string type, string input){
            return SPcontext.SanPhams_AdminTimKiem(type, input).MappingSanPhamDtos();
        }

        public void SanPham_Update_Status_By_Product_type_id(int product_type_id, int status){
            SPcontext.SanPham_Update_Status_By_Product_type_id(product_type_id, status);
        }
    }
}