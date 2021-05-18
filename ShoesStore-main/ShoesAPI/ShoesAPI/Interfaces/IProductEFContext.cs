using System.Collections.Generic;
using ShoesAPI.Models;

namespace ShoesAPI.Interfaces
{
    public interface IProductEFContext
    {
        IEnumerable<Product> SanPham_GetAll();
        IEnumerable<Product> SanPham_Shop_GetAll();
        Product SanPham_GetById(int id);
        void SanPham_Add(Product SP);
        void SanPham_Update(Product SP);
        void SanPham_Remove(Product SP);
        void SanPham_RemoveBy_Product_Type_Id(int product_type_id);
        IEnumerable<Product> SanPham_Filter(string Type, string qSearch, string price, string sort, int pageIndex, int pageSize, out int count, out decimal pricemax);
        IEnumerable<Product> TenSPChay();
        IEnumerable<Product> TenSPNoi();
        IEnumerable<Product> SanPham_ListCart(string list);
        IEnumerable<Product> SanPhams_AdminTimKiem(string type, string input);
        void SanPham_Update_Status_By_Product_type_id(int product_type_id, int status);
    }
}