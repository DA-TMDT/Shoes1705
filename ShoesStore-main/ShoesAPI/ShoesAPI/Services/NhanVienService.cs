using System.Collections.Generic;
using ShoesAPI.DTOs;
using ShoesAPI.Interfaces;
using ShoesAPI.Mappings;
namespace ShoesAPI.Services
{
    public class NhanVienService
    {
        private readonly INhanVienEFContext NVcontext;
        public NhanVienService(INhanVienEFContext NVcontext){
            this.NVcontext = NVcontext;
        }
        public IEnumerable<NhanVienDto> NhanVien_GetAll(){
            var q = NVcontext.NhanVien_GetAll();
            return q.MappingNhanVienDtos();
        }

        public NhanVienDto NhanVien_GetByUser(string user){
            var q = NVcontext.NhanVien_GetByUser(user);
            if(q == null) return null;
            return q.MappingNhanVienDto();
        }

        public void NhanVien_Add(NhanVienDto NVdto){
            var q = NVdto.MappingNhanVien();
            NVcontext.NhanVien_Add(q);
        }

        public void NhanVien_Update(NhanVienDto NVdto){
            var q = NVcontext.NhanVien_GetByUser(NVdto.user);
            if(q == null) return;
            NVdto.MappingNhanVien(q);
            NVcontext.NhanVien_Update(q);
        }

        public void NhanVien_Remove(string user){
            var q = NVcontext.NhanVien_GetByUser(user);
            if(q == null) return;
            NVcontext.NhanVien_Remove(q);
        }
        public IEnumerable<NhanVienDto> NhanVien_AdminTimKiem(string type, string input) {
            return NVcontext.NhanVien_AdminTimKiem(type, input).MappingNhanVienDtos();
        }
    }
}