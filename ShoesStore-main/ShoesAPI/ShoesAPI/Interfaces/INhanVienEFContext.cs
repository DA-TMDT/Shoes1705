using System.Collections.Generic;
using ShoesAPI.Models;
namespace ShoesAPI.Interfaces
{
    public interface INhanVienEFContext
    {
        IEnumerable<NhanVien> NhanVien_GetAll();
        NhanVien NhanVien_GetByUser(string user);
        void NhanVien_Add(NhanVien q);
        void NhanVien_Update(NhanVien q);
        void NhanVien_Remove(NhanVien q);
        IEnumerable<NhanVien> NhanVien_AdminTimKiem(string type, string input);
    }
}