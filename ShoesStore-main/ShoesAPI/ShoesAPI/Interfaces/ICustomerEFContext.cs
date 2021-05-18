using System.Collections.Generic;
using ShoesAPI.Models;

namespace ShoesAPI.Interfaces
{
    public interface ICustomerEFContext
    {
        List<Customer> KhachHang_GetAll();
        Customer KhachHang_GetByUser(string user);
        void KhachHang_Add(Customer U);
        void KhachHang_Update(Customer U);
        void KhachHang_Remove(Customer U);
        IEnumerable<Customer> KhachHang_AdminTimKiem(string type, string input);
    }
}