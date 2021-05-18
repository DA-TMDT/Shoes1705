using System.Collections.Generic;
using ShoesAPI.DTOs;
using ShoesAPI.Models;

namespace ShoesAPI.Mappings
{
    public static class MappingCustomerProfile
    {
        public static CustomerDto MappingCustomerDto(this Customer customer){
            return new CustomerDto{
                user = customer.user,
                pass = customer.pass,
                full_name = customer.full_name,
                phone = customer.phone,
                mail = customer.mail,
                address = customer.address,
                sex = customer.sex,
                dateborn = customer.dateborn,
                status = customer.status
            };
        }

        public static Customer MappingCustomer(this CustomerDto customerdto){
            return new Customer{
                user = customerdto.user,
                pass = customerdto.pass,
                full_name = customerdto.full_name,
                phone = customerdto.phone,
                mail = customerdto.mail,
                address = customerdto.address,
                sex = customerdto.sex,
                dateborn = customerdto.dateborn,
                status = customerdto.status
            };
        }

        public static void MappingCustomer(this CustomerDto customerdto, Customer customer){
            // khachhang.user = khachhangdto.user;
            customer.pass = customerdto.pass;
            customer.full_name = customerdto.full_name;
            customer.phone = customerdto.phone;
            customer.mail = customerdto.mail;
            customer.address = customerdto.address;
            customer.sex = customerdto.sex;
            customer.dateborn = customerdto.dateborn;
            customer.status = customerdto.status;
        }

        public static IEnumerable<CustomerDto> MappingCustomerDtos(this IEnumerable<Customer> customers){
            foreach(var i in customers){
                yield return i.MappingCustomerDto();
            }
        }
    }
}