using System.Collections.Generic;
using ShoesAPI.DTOs;
using ShoesAPI.Models;

namespace ShoesAPI.Mappings
{
    public static class MappingSanPhamProfile
    {
        public static ProductDto MappingSanPhamDto(this Product sp){
            return new ProductDto{
                product_id = sp.product_id,
                product_type_id = sp.product_type_id,
                name = sp.name,
                amount = sp.amount,
                price = sp.price,
                description = sp.description,
                img = Constants.apiUrlImg + sp.img,
                size = sp.size,
                status = sp.status
            };
        }

        public static Product MappingSanPham(this ProductDto spdto){
            return new Product{
                product_id = spdto.product_id,
                product_type_id = spdto.product_type_id,
                name = spdto.name,
                amount = spdto.amount,
                price = spdto.price,
                description = spdto.description,
                img = spdto.img.Replace(Constants.apiUrlImg, ""),
                size = spdto.size,
                status = spdto.status
            };
        }

        public static void MappingSanPham(this ProductDto spdto, Product sp){
            // sp.product_id = spdto.product_id;
            sp.product_type_id = spdto.product_type_id;
            sp.name = spdto.name;
            sp.amount = spdto.amount;
            sp.price = spdto.price;
            sp.description = spdto.description;
            sp.img = spdto.img.Replace(Constants.apiUrlImg, "");
            sp.status = spdto.status;
        }

        public static IEnumerable<ProductDto> MappingSanPhamDtos(this IEnumerable<Product> sps){
            foreach(var sp in sps){
                yield return sp.MappingSanPhamDto();
            }
        }

        public static IEnumerable<Product> MappingSanPhams(this IEnumerable<ProductDto> spdtos)
        {
            foreach (var sp in spdtos)
            {
                yield return sp.MappingSanPham();
            }
        }
    }
}