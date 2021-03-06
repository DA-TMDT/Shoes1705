using System.Collections.Generic;
using ShoesAPI.Models;

namespace ShoesAPI.Interfaces
{
    public interface ILoaiSanPhamEFContext
    {
        IEnumerable<LoaiSanPham> LoaiSanPham_GetAll();
        LoaiSanPham LoaiSanPham_GetById(int id);
        void LoaiSanPham_Add(LoaiSanPham LSP);
        void LoaiSanPham_Update(LoaiSanPham LSP);
        void LoaiSanPham_Remove(LoaiSanPham LSP);
        IEnumerable<LoaiSanPham> LoaiSanPham_AdminTimKiem(string type, string input);
        int LoaiSanPham_GetMaxId();
    }
}