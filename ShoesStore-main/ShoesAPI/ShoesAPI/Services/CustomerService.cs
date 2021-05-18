using System.Collections.Generic;
using ShoesAPI.DTOs;
using ShoesAPI.Interfaces;
using ShoesAPI.Mappings;

namespace ShoesAPI.Services
{
    public class CustomerService
    {
        private readonly ICustomerEFContext KHcontext;
        public CustomerService(ICustomerEFContext KHcontext){
            this.KHcontext = KHcontext;
        }
        public IEnumerable<CustomerDto> KhachHang_GetAll(){
            var khs = KHcontext.KhachHang_GetAll();
            return khs.MappingCustomerDtos();
        }
        public CustomerDto KhachHang_GetByUser(string user){
            var kh = KHcontext.KhachHang_GetByUser(user);
            if(kh == null) return null;
            return kh.MappingCustomerDto();
        }
        public void KhachHang_Add(CustomerDto U){
            var kh = U.MappingCustomer();
            KHcontext.KhachHang_Add(kh);
        }

        public void KhachHang_Update(CustomerDto U){
            var kh = KHcontext.KhachHang_GetByUser(U.user);
            if(kh == null) return;
            U.MappingCustomer(kh);
            KHcontext.KhachHang_Update(kh);
        }

        public void KhachHang_Remove(string user){
            var kh = KHcontext.KhachHang_GetByUser(user);
            if(kh == null) return;
            KHcontext.KhachHang_Remove(kh);
        }
        public IEnumerable<CustomerDto> KhachHang_AdminTimKiem(string type, string input){
            return KHcontext.KhachHang_AdminTimKiem(type, input).MappingCustomerDtos();
        }
    }
}