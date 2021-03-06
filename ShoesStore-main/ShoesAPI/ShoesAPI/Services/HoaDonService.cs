using System.Collections.Generic;
using ShoesAPI.DTOs;
using ShoesAPI.Interfaces;
using ShoesAPI.Mappings;
namespace ShoesAPI.Services
{
    public class HoaDonService
    {
        private readonly IHoaDonEFContext HDcontext;
        public HoaDonService(IHoaDonEFContext HDcontext){
            this.HDcontext = HDcontext;
        }
        public IEnumerable<HoaDonDto> HoaDon_GetAll(){
            var hd = HDcontext.HoaDon_GetAll();
            return hd.MappingHoaDonDtos();
        }

        public HoaDonDto HoaDon_GetById(int id){
            var hd = HDcontext.HoaDon_GetById(id);
            if(hd == null) return null;
            return hd.MappingHoaDonDto();
        }

        public void HoaDon_Add(HoaDonDto hddto){
            var hd = hddto.MappingHoaDon();
            HDcontext.HoaDon_Add(hd);
        }

        public void HoaDon_Update(HoaDonDto hddto){
            var hd = HDcontext.HoaDon_GetById(hddto.bill_id);
            if(hd == null) return;
            hddto.MappingHoaDon(hd);
            HDcontext.HoaDon_Update(hd);
        }

        public void HoaDon_Remove(int bill_id){
            var hd = HDcontext.HoaDon_GetById(bill_id);
            if(hd == null) return;
            HDcontext.HoaDon_Remove(hd);
        }

        public IEnumerable<HoaDonDto> HoaDon_Manager_TimKiem(string type, string input, int status){
            var hds = HDcontext.HoaDon_Manager_TimKiem(type, input, status);
            return hds.MappingHoaDonDtos();
        }
        public int HoaDon_GetMaxId(){
            return HDcontext.HoaDon_GetMaxId();
        }
    }
}