using System.Collections.Generic;
using System.Linq;
using ShoesAPI.Models;

namespace ShoesAPI.Persistence
{
    public class SeedData
    {
        public static void Initialize(PhoneStoreDBContext context) {
            context.Database.EnsureCreated();
            bool temp = false;
            //Quyen            
            if (!context.Quyens.Any()) {
                temp = true;
                context.Quyens.AddRange(new List<Quyen>{
                    new Quyen{
                        permission_id = 1,
                        name = "Admin",
                        details = "qlNhapHang-qlNhanVien-qlSanPham-qlHoaDon-qlKhachHang-qlPhieuNhap-qlNCC-qlTaiKhoan-qlQuyen-qlThongKe-qlLoaiSanPham"
                    },
                    new Quyen{
                        permission_id = 2,
                        name = "Quản lý",
                        details = "qlNhanVien-xemSanPham-xemHoaDon-qlKhachHang-xemPhieuNhap-xemNCC-qlTaiKhoan-qlThongKe-qlLoaiSanPham"
                    },
                    new Quyen{
                        permission_id = 3,
                        name = "Nhân viên bán hàng",
                        details = "xemSanPham-qlHoaDon-xemKhachHang-qlThongKe"
                    },
                    new Quyen{
                        permission_id = 4,
                        name = "Nhân viên nhập hàng",
                        details = "qlNhapHang-qlSanPham-qlPhieuNhap-qlNCC-qlThongKe-qlLoaiSanPham"
                    }
                });   
            }
            //Chi tiet hd
            if (!context.ChiTietHDs.Any()) {
                temp = true;
                context.ChiTietHDs.AddRange(new List<ChiTietHD>{
                    new ChiTietHD{
                        bill_id = 1,
                        product_id = 1,
                        name = "Vietnam Arising R3 Gold",
                        amount = 1,
                        price = 1499000,
                        img = "sp1.jpg"
                    },
                    new ChiTietHD{
                        bill_id = 2,
                        product_id = 2,
                        name = "Biti's Hunter Core Festive Breezer Black",
                        amount = 1,
                        price = 799000,
                        img = "sp2.jpg"
                    }
                });   
            }
            //Hoa don
            if (!context.HoaDons.Any()) {
                temp = true;
                context.HoaDons.AddRange(new List<HoaDon>{
                    new HoaDon{
                        bill_id = 1,
                        user_kh = "thien",
                        user_nv = "bh01",
                        phone = "0364117408",
                        address = "Bình Định",
                        date_receice = new System.DateTime(2020, 5, 8, 5, 4, 6),
                        date_order = new System.DateTime(2020, 5, 18, 5, 4, 6),
                        total = 15000000,
                        status = 3
                    },
                    new HoaDon{
                        bill_id = 2,
                        user_kh = "thinh",
                        user_nv = "",
                        phone = "0364117408",
                        address = "Miền Tây",
                        date_receice = null,
                        date_order = new System.DateTime(2020, 5, 18, 5, 4, 6),
                        total = 25290000,
                        status = 2
                    },
                    new HoaDon{
                        bill_id = 3,
                        user_kh = "cungthien",
                        user_nv = "",
                        phone = "0364117408",
                        address = "Bình Dương",
                        date_receice = null,
                        date_order = new System.DateTime(2020, 5, 18, 5, 4, 6),
                        total = 10290000,
                        status = 1
                    }
                });   
            }

            //Khach hang
            if (!context.KhachHangs.Any()) {
                temp = true;
                context.KhachHangs.AddRange(new List<KhachHang>{
                    new KhachHang{
                        user = "thien",
                        pass = "1234",
                        full_name = "Nguyễn Ngọc Thiện",
                        phone = "0364117408",
                        mail = "tructruong.070202@gmail.com",
                        address = "Bình Định",
                        sex = "Nam",
                        dateborn = new System.DateTime(2000, 5, 8),
                        status = 1
                    },
                    new KhachHang{
                        user = "thinh",
                        pass = "1234",
                        full_name = "Nguyễn Phước Thịnh",
                        phone = "0364117408",
                        mail = "thinh@gmail.com",
                        address = "Hồ Chí Minh",
                        sex = "Nam",
                        dateborn = new System.DateTime(2000, 5, 8),
                        status = 1
                    },
                    new KhachHang{
                        user = "cungthien",
                        pass = "1234",
                        full_name = "Cung Xương Hồng Thiên",
                        phone = "0364117408",
                        mail = "thinh@gmail.com",
                        address = "Hồ Chí Minh",
                        sex = "Nam",
                        dateborn = new System.DateTime(2000, 5, 8),
                        status = 1
                    }
                });   
            }
            //Nhân viên
            if (!context.NhanViens.Any()) {
                temp = true;
                context.NhanViens.AddRange(new List<NhanVien>{
                    new NhanVien{
                        user = "admin",
                        pass = "admin",
                        full_name = "Nguyễn Tấn Thông",
                        phone = "0962875187",
                        mail = "thong@gmail.com",
                        address = "Hồ Chí Minh",
                        sex = "Nam",
                        dateborn = new System.DateTime(2000, 5, 8),
                        permission_id = 1,
                        status = 1
                    },
                    new NhanVien{
                        user = "ql01",
                        pass = "ql01",
                        full_name = "Lê Đặng Khánh Dung",
                        phone = "0987654321",
                        mail = "dung@gmail.com",
                        address = "Hồ Chí Minh",
                        sex = "Nữ",
                        dateborn = new System.DateTime(2000, 5, 8),
                        permission_id = 2,
                        status = 1
                    },
                    new NhanVien{
                        user = "bh02",
                        pass = "bh02",
                        full_name = "Nguyễn Văn A",
                        phone = "0987654321",
                        mail = "vana@gmail.com",
                        address = "Hồ Chí Minh",
                        sex = "Nam",
                        dateborn = new System.DateTime(2000, 5, 8),
                        permission_id = 3,
                        status = 1
                    },
                    new NhanVien{
                        user = "bh01",
                        pass = "bh01",
                        full_name = "Trần Văn B",
                        phone = "0987654321",
                        mail = "vanb@gmail.com",
                        address = "Hồ Chí Minh",
                        sex = "Nam",
                        dateborn = new System.DateTime(2000, 5, 8),
                        permission_id = 3,
                        status = 1
                    },
                    new NhanVien{
                        user = "nh01",
                        pass = "nh01",
                        full_name = "Lê Thị C",
                        phone = "0987654321",
                        mail = "vanc@gmail.com",
                        address = "Hồ Chí Minh",
                        sex = "Nữ",
                        dateborn = new System.DateTime(2000, 5, 8),
                        permission_id = 4,
                        status = 1
                    }
                });   
            }
            //loai san pham
            if(!context.LoaiSanPhams.Any()) {
                temp = true;
                context.LoaiSanPhams.AddRange(new List<LoaiSanPham>{
                    new LoaiSanPham{
                        product_type_id =  1,
                        name =  "BITIS",
                        description =  "BITIS",
                        status=1
                    },
                    new LoaiSanPham{
                        product_type_id =  2,
                        name =  "NIKE",
                        description =   "NIKE",
                        status=1
                    },
                    new LoaiSanPham{
                        product_type_id = 3,
                        name =  "VANS",
                        description =  "VANS",
                        status=1
                    },
                    new LoaiSanPham{
                        product_type_id = 4,
                        name =  "ADIDAS" ,
                        description =  "ADIDAS",
                        status=1
                    }
                });  
            }
            //sản phẩm
            if(!context.SanPhams.Any()) {
                temp = true;
                context.SanPhams.AddRange(new List<SanPham>{
                    new SanPham{
                    product_id =1,
                        name="Biti's Hunter X Festive Aurora",
                        product_type_id=1,
                        amount=50,
                        price=1999000,
                        description=  "Giày Thể Thao Nam Biti's Hunter X Festive Aurora Black DSMH03401XDG (xanh Dương)",
                        img="sp1.jpg",
                        size="40",
                        status=1  
                    },
                    new SanPham{
                    product_id =2,
                        name="Biti's Hunter Core Festive Breezer",
                        product_type_id=1,
                        amount=50,
                        price=799000,
                        description=  "Giày Thể Thao Nam Biti's Hunter Core Festive Breezer Black DSMH04200DEN (Đen)",
                        img="sp2.jpg",
                        size="42",
                        status=1 
                    },
                    new SanPham{
                    product_id =3,
                        name="Biti's Hunter X Army Green",
                        product_type_id=1,
                        amount=50,
                        price=999000,
                        description=  "Giày Thể Thao Cao Cấp Nam Biti's Hunter X Army Green DSMH05100REU (Rêu)",
                        img="sp3.jpg",
                        size="40",
                        status=1  
                    },
                    new SanPham{
                    product_id =4,
                        name="Biti's Hunter BKL Tết Edition 2020",
                        product_type_id=1,
                        amount=50,
                        price=629000,
                        description=  "Giày Thể Thao Nam Biti's Hunter BKL Tết Edition 2020 DSMH02301DOO (Đỏ)",
                        img="sp4.jpg",
                        size="40",
                        status=1  
                    },
                    new SanPham{
                    product_id =5,
                        name="Biti's Hunter X 2k19 - Jet Navy",
                        product_type_id=1,
                        amount=50,
                        price=899000,
                        description=  "Giày Thể Thao Nam Biti's Hunter X 2k19 - Jet Navy DSMH02200XNH (Xanh Nhớt)",
                        img="sp5.jpg",
                        size="39",
                        status=1  
                    },
                    new SanPham{
                    product_id =6,
                        name="Vietnamese Canvas of Pride",
                        product_type_id=1,
                        amount=50,
                        price=899000,
                        description=  "Việt Nam Vững Tin - Vietnamese Canvas of Pride (Man)",
                        img="sp6.jpg",
                        size="35",
                        status=1  
                    },
                    new SanPham{
                    product_id =7,
                        name="Biti's Hunter Street x Vietmax 2020",
                        product_type_id=1,
                        amount=50,
                        price=899000,
                        description=  "Giày Thể Thao Nam Biti's Hunter Street x Vietmax 2020 - BST HaNoi Culture Patchwork Lake Turquoise DSMH02504XNG (Xanh Ngọc)",
                        img="sp7.jpg",
                        size="43",
                        status=1  
                    },
                    new SanPham{
                    product_id =8,
                        name="Biti's Hunter Street x Vietmax 2020",
                        product_type_id=1,
                        amount=50,
                        price=899000,
                        description=  "Giày Thể Thao Nam Biti's Hunter Street x Vietmax 2020 - BST HaNoi Culture Patchwork Old Wall Yellow DSMH02503NAU (Nâu)",
                        img="sp8.jpg",
                        size="44",
                        status=1  
                    },
                    new SanPham{
                    product_id =9,
                        name="Biti's Hunter Street Mid Kumquat Soda",
                        product_type_id=1,
                        amount=50,
                        price=699000,
                        description=  "Giày Thể Thao Nam Biti's Hunter Street Mid Kumquat Soda DSMH03601TRG (Trắng)",
                        img="sp9.jpg",
                        size="37",
                        status=1  
                    },
                    new SanPham{
                    product_id =10,
                        name="Biti's Hunter Street Mid Orange Milk",
                        product_type_id=1,
                        amount=50,
                        price=699000,
                        description=  "Giày Thể Thao Nam Biti's Hunter Street Mid Orange Milk DSMH03601CAM (Cam)",
                        img="sp10.jpg",
                        size="41",
                        status=1  
                    },
                    new SanPham{
                    product_id =11,
                        name="Biti's Hunter Street Festive Low-Cut Slate Black",
                        product_type_id=1,
                        amount=50,
                        price=699000,
                        description=  "Giày Thể Thao Nam Biti's Hunter Street Festive Low-Cut Slate Black DSMH04300DEN (Đen)",
                        img="sp11.jpg",
                        size="38",
                        status=1  
                    },
                    new SanPham{
                    product_id =12,
                        name="Biti’s Hunter X - Summer 2K19",
                        product_type_id=1,
                        amount=50,
                        price=539000,
                        description=  "Giày Thể Thao Cao Cấp Nam Biti’s Hunter X - Summer 2K19 ADVENTURE COLLECTION - Fired Red DSMH01100DOO (Đỏ)",
                        img="sp12.jpg",
                        size="40",
                        status=1  
                    },
                    new SanPham{
                    product_id =13,
                        name="Biti's Hunter Street Festive Low-Cut Duke",
                        product_type_id=1,
                        amount=50,
                        price=699000,
                        description=  "Giày Thể Thao Nam Biti's Hunter Street Festive Low-Cut Duke Blue DSMH04300XNH (Xanh Nhớt)",
                        img="sp13.jpg",
                        size="40",
                        status=1  
                    },
                    new SanPham{
                    product_id =14,
                        name="HU NMD",
                        product_type_id=4,
                        amount=50,
                        price=6000000,
                        description=  "Giày Adidas",
                        img="sp14.jpg",
                        size="42",
                        status=1  
                    }
                });  
            }

            if (temp) {
                context.SaveChanges();
            }
        }
    }
}