using System.Collections.Generic;
using ShoesAPI.Models;

namespace ShoesAPI.Interfaces
{
    public interface IHoaDonEFContext
    {
        IEnumerable<HoaDon> HoaDon_GetAll();
        HoaDon HoaDon_GetById(int id);
        void HoaDon_Add(HoaDon hd);
        void HoaDon_Update(HoaDon hd);
        void HoaDon_Remove(HoaDon hd);
        IEnumerable<HoaDon> HoaDon_Manager_TimKiem(string type, string input, int status);
        int HoaDon_GetMaxId();
    }
}