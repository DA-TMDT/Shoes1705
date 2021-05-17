using System.Collections.Generic;
using ShoesAPI.DTOs;
using ShoesAPI.Models;

namespace ShoesAPI.Mappings
{
    public static class MappingLoaiSanPhamProfile
    {
        public static LoaiSanPhamDto MappingLoaiSanPhamDto(this LoaiSanPham lsp){
            return new LoaiSanPhamDto{
                product_type_id = lsp.product_type_id,
                name = lsp.name,
                description = lsp.description,
                status = lsp.status
            };
        }

        public static LoaiSanPham MappingLoaiSanPham(this LoaiSanPhamDto lspdto){
            return new LoaiSanPham{
                product_type_id = lspdto.product_type_id,
                name = lspdto.name,
                description = lspdto.description,
                status = lspdto.status
            };
        }

        public static void MappingLoaiSanPham(this LoaiSanPhamDto lspdto, LoaiSanPham lsp){
            // lsp.product_type_id = lspdto.product_type_id;
            lsp.name = lspdto.name;
            lsp.description = lspdto.description;
            lsp.status = lspdto.status;
        }

        public static IEnumerable<LoaiSanPhamDto> MappingLoaiSanPhamDtos(this IEnumerable<LoaiSanPham> lsps){
            foreach(var lsp in lsps){
                yield return lsp.MappingLoaiSanPhamDto();
            }
        }
    }
}