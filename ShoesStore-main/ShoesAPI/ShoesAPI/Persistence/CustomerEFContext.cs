using System.Collections.Generic;
using System.Linq;
using ShoesAPI.Interfaces;
using ShoesAPI.Models;

namespace ShoesAPI.Persistence
{
    public class CustomerEFContext : ICustomerEFContext
    {
        private readonly ShoesStoreDBContext context;
        public CustomerEFContext(ShoesStoreDBContext context){
            this.context = context;
        }
        public List<Customer> KhachHang_GetAll(){
            return context.Customers.ToList();
        }

        public Customer KhachHang_GetByUser(string user){
            return context.Customers.Find(user);
        }

        public void KhachHang_Add(Customer U){
            context.Customers.Add(U);
            context.SaveChanges();
        }

        public void KhachHang_Update(Customer U){
            context.Customers.Update(U);
            context.SaveChanges();
        }

        public void KhachHang_Remove(Customer U){
            context.Customers.Remove(U);
            context.SaveChanges();
        }

        public IEnumerable<Customer> KhachHang_AdminTimKiem(string type, string input){
            var query = context.Customers.AsQueryable();
            switch(type){
                case "all": {
                    input = input.Trim().ToLower();
                    if(input == ""){
                        return KhachHang_GetAll();
                    }
                    query = query.Where(m => m.user.ToLower().Contains(input) || m.full_name.ToLower().Contains(input) ||
                    m.phone.ToLower().Contains(input) || m.mail.ToLower().Contains(input) || m.address.ToLower().Contains(input));
                    break;
                }
                case "user": {
                    input = input.Trim().ToLower();
                    query = query.Where(m => m.user.ToLower().Contains(input));
                    break;
                }
                case "full_name": {
                    input = input.Trim().ToLower();
                    query = query.Where(m => m.full_name.ToLower().Contains(input));
                    break;
                }
                case "phone":{
                    input = input.Trim().ToLower();
                    query = query.Where(m => m.phone.ToLower().Contains(input));
                    break;
                }
                case "mail":{
                    input = input.Trim().ToLower();
                    query = query.Where(m => m.mail.ToLower().Contains(input));
                    break;
                }
                case "address":{
                    input = input.Trim().ToLower();
                    query = query.Where(m => m.address.ToLower().Contains(input));
                    break;
                }
                default: break;
            }
            return query.ToList();
        }
    }
}