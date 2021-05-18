using System.Collections.Generic;
using System.Linq;
using ShoesAPI.Models;

namespace ShoesAPI.Persistence
{
    public class SeedData
    {
        public static void Initialize(ShoesStoreDBContext context) {
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
            if (!context.Customers.Any()) {
                temp = true;
                context.Customers.AddRange(new List<Customer>{
                    new Customer{
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
                    new Customer{
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
                    new Customer{
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
            if(!context.Products.Any()) {
                temp = true;
                context.Products.AddRange(new List<Product>{
                    new Product{
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
                    new Product{
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
                    new Product{
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
                    new Product{
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
                    new Product{
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
                    new Product{
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
                    new Product{
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
                    new Product{
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
                    new Product{
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
                    new Product{
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
                    new Product{
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
                    new Product{
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
                    new Product{
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
                    new Product{
                    product_id =14,
                        name="HU NMD",
                        product_type_id=4,
                        amount=50,
                        price=6000000,
                        description=  "Giày Adidas",
                        img="sp14.jpg",
                        size="42",
                        status=1  
                    },
                    new Product{
                    product_id =17,
                        name="Nike Air Max 95 SE",
                        product_type_id=2,
                        amount=50,
                        price=4999000,
                        description=  "Lấy cảm hứng từ cơ thể con người và tính thẩm mỹ từ các môn thể thao thập niên 90, Nike Air Max 95 SE kết hợp sự thoải mái đến khó tin và phong cách quay đầu với một thiết kế bền vững. denim và lưới. Đồ họa nút chai thêu trên lưỡi gật đầu với loại cây được sử dụng trong thiết kế. Không khí có thể xử lý được ở gót chân và đệm bàn chân trước mỗi bước đi. ",
                        img="sp15.jpg",
                        size="42",
                        status=1  
                    },
                    new Product{
                    product_id =18,
                        name="Nike Air Force 1 '07 LV8",
                        product_type_id=2,
                        amount=50,
                        price=2929000,
                        description=  "Nike Air Force 1 '07 LV8 cập nhật phiên bản gốc '82 lấy cảm hứng từ vòng đệm với ít nhất 20% nội dung tái chế theo trọng lượng và đế ngoài bằng nút chai. Với họa tiết cây lựu bao gồm màu nhuộm thực vật thật, thiết kế thêu thực vật và đồ họa thông tin khoa học, đó là một sự thay đổi tự nhiên của tác phẩm cổ điển mà chúng ta đều biết và yêu thích. ",
                        img="sp18.jpg",
                        size="42",
                        status=1  
                    },
                    new Product{
                    product_id =19,
                        name="Nike Air Force 1 '07 Premium",
                        product_type_id=2,
                        amount=50,
                        price=3829000,
                        description=  "Nâng niu con vật bên trong của bạn với Nike Air Force 1 '07 Premium, quả bóng b-ball OG mang đến một sự thay đổi mới mẻ cho những gì bạn biết rõ nhất: da sắc nét, màu sắc sạch sẽ và lượng đèn flash hoàn hảo để khiến bạn tỏa sáng. và logo Swoosh mượt mà khiến chiếc AF-1 này trở thành một chuyến đi săn cho đôi chân của bạn. ",
                        img="sp19.jpg",
                        size="42",
                        status=1  
                    },
                    new Product{
                    product_id =20,
                        name="Nike Air Force 1 '07 Premium",
                        product_type_id=2,
                        amount=50,
                        price=3829000,
                        description=  "Nâng niu con vật bên trong của bạn với Nike Air Force 1 '07 Premium, quả bóng b-ball OG mang đến một sự thay đổi mới mẻ cho những gì bạn biết rõ nhất: da sắc nét, màu sắc sạch sẽ và lượng đèn flash hoàn hảo để khiến bạn tỏa sáng. và logo Swoosh mượt mà khiến chiếc AF-1 này trở thành một chuyến đi săn cho đôi chân của bạn. ",
                        img="sp20.jpg",
                        size="42",
                        status=1  
                    },
                    new Product{
                    product_id =21,
                        name="Nike AF 1/1",
                        product_type_id=2,
                        amount=50,
                        price=4109000,
                        description=  "Sự rạng rỡ tồn tại trong Nike AF 1/1, biểu tượng quả bóng b-ball mang đến sự xoay chuyển phù hợp với những gì bạn biết rõ nhất: da tổng hợp sắc nét, đường nét sạch sẽ và lượng đèn flash hoàn hảo để bạn tỏa sáng. Thiết kế mới, có thể tùy chỉnh có phần trên móc và vòng với các lớp phủ có thể tháo rời để bạn thay đổi diện mạo của mình cho phù hợp với ngày. ",
                        img="sp21.jpg",
                        size="42",
                        status=1  
                    },
                    new Product{
                    product_id =22,
                        name="Nike Air Force 1 '07 LV8",
                        product_type_id=2,
                        amount=50,
                        price=2929000,
                        description=  "Sự rạng rỡ còn tồn tại trong Nike Air Force 1 '07, biểu tượng quả bóng b mang một góc quay biểu cảm về những gì bạn biết rõ nhất: da sắc nét, màu sắc đậm và lượng đèn flash hoàn hảo để khiến bạn tỏa sáng. Tôn vinh nghệ thuật và phong cách DIY, phần sơn bắn tung tóe phía trên mời bạn thêm vào nét nghệ thuật của riêng mình. Hoặc mặc nguyên tấm vải và quay đầu lại với thiết kế có một không hai của nó. ",
                        img="sp22.jpg",
                        size="42",
                        status=1  
                    },
                    new Product{
                    product_id =23,
                        name="Zion 1 PF",
                        product_type_id=2,
                        amount=50,
                        price=3529000,
                        description=  "Với một tính cách bình thường và những khả năng vượt ra ngoài thế giới này, Zion không giống bất kỳ ai khác. dòng chữ ký với thiết kế lấy cảm hứng từ tính khiêm tốn và khả năng siêu phàm của anh ấy. Đệm Air Strobel có chiều dài hoàn chỉnh được xếp chồng lên nhau với bộ phận Zoom Air ở bàn chân trước — một sự kết hợp thú vị giữa sự thoải mái dưới chân sang trọng và khả năng phản hồi nhanh. Nhẹ, ổn định và mạnh mẽ, với lực kéo mạnh mẽ giúp Zion bám sân và kiểm soát sức mạnh của mình. Phiên bản PF này sử dụng đế ngoài siêu bền được thiết kế cho các sân ngoài trời. ",
                        img="sp23.jpg",
                        size="42",
                        status=1  
                    },
                    new Product{
                    product_id =24,
                        name="Zion 1 'ZNA'",
                        product_type_id=2,
                        amount=50,
                        price=3529000,
                        description=  "Một số người gọi nó là yếu tố X, một phẩm chất bí ẩn, vô hình sống bên trong. Đó là một sức mạnh mạnh mẽ đến mức khi kết hợp với cam kết vĩ đại vô song, nó tạo ra một thứ mà thế giới chưa từng thấy. , anh ta được định sẵn để thách thức, nhưng không ai, không mô hình, không lý thuyết nào có thể dự đoán được hiện tượng Zion. thế giới có thể không bao giờ hiểu được. ",
                        img="sp24.jpg",
                        size="42",
                        status=1  
                    },
                    new Product{
                    product_id =25,
                        name="Zion 1 PF",
                        product_type_id=2,
                        amount=50,
                        price=3529000,
                        description=  "Với một tính cách bình thường và những khả năng vượt ra ngoài thế giới này, Zion không giống bất kỳ ai khác. dòng chữ ký với thiết kế lấy cảm hứng từ tính khiêm tốn và khả năng siêu phàm của anh ấy. Đệm Air Strobel có chiều dài hoàn chỉnh được xếp chồng lên nhau với bộ phận Zoom Air ở bàn chân trước — một sự kết hợp thú vị giữa sự thoải mái dưới chân sang trọng và khả năng phản hồi nhanh. Nhẹ, ổn định và mạnh mẽ, với lực kéo mạnh mẽ giúp Zion bám sân và kiểm soát sức mạnh của mình. Phiên bản PF này sử dụng đế ngoài siêu bền được thiết kế cho các sân ngoài trời. ",
                        img="sp25.jpg",
                        size="42",
                        status=1  
                    },
                    new Product{
                    product_id =27,
                        name="Nike Air Zoom Pegasus 38",
                        product_type_id=2,
                        amount=50,
                        price=3519000,
                        description=  "Nike Air Zoom Pegasus 38 tiếp tục tạo ra một lò xo trong bước đi của bạn, sử dụng bọt phản ứng tương tự như người tiền nhiệm của nó. ",
                        img="sp27.jpg",
                        size="42",
                        status=1  
                    },
                    new Product{
                    product_id =28,
                        name="Nike Air Zoom Pegasus 38",
                        product_type_id=2,
                        amount=50,
                        price=3519000,
                        description=  "Nike Air Zoom Pegasus 38 tiếp tục tạo ra một lò xo trong bước đi của bạn, sử dụng bọt phản ứng tương tự như người tiền nhiệm của nó. ",
                        img="sp28.jpg",
                        size="42",
                        status=1  
                    },
                    new Product{
                    product_id =29,
                        name="Nike Air Zoom Pegasus 38",
                        product_type_id=2,
                        amount=50,
                        price=3519000,
                        description=  "Nike Air Zoom Pegasus 38 tiếp tục tạo ra một lò xo trong bước đi của bạn, sử dụng bọt phản ứng tương tự như người tiền nhiệm của nó. ",
                        img="sp29.jpg",
                        size="42",
                        status=1  
                    },
                    new Product{
                    product_id =30,
                        name="Nike Air Zoom Pegasus 38",
                        product_type_id=2,
                        amount=50,
                        price=3519000,
                        description=  "Nike Air Zoom Pegasus 38 tiếp tục tạo ra một lò xo trong bước đi của bạn, sử dụng bọt phản ứng tương tự như người tiền nhiệm của nó. ",
                        img="sp30.jpg",
                        size="42",
                        status=1  
                    },
                    new Product{
                    product_id =31,
                        name="Nike Air Force 1 '07 Craft",
                        product_type_id=2,
                        amount=50,
                        price=3829000,
                        description=  "Sự rạng rỡ còn tồn tại trong Nike Air Force 1 '07 Craft, biểu tượng quả bóng b mang lại sự tươi mới cho những gì bạn biết rõ nhất: lớp phủ được khâu, màu sắc đậm và lượng đèn flash hoàn hảo để khiến bạn tỏa sáng. ",
                        img="sp31.jpg",
                        size="42",
                        status=1  
                    },
                    new Product{
                    product_id =32,
                        name="Nike Air Force 1 '07 Craft",
                        product_type_id=2,
                        amount=50,
                        price=3829000,
                        description=  "Sự rạng rỡ còn tồn tại trong Nike Air Force 1 '07 Craft, biểu tượng quả bóng b mang lại sự tươi mới cho những gì bạn biết rõ nhất: lớp phủ được khâu, màu sắc đậm và lượng đèn flash hoàn hảo để khiến bạn tỏa sáng. ",
                        img="sp32.jpg",
                        size="42",
                        status=1  
                    },
                    new Product{
                    product_id =33,
                        name="VANS OLD SKOOL CLASSIC BLACK/WHITE",
                        product_type_id=3,
                        amount=50,
                        price=1499000,
                        description=  "VANS OLD SKOOL CLASSIC BLACK/WHITE Là một trong những phiên bản đầu tiên và cổ điển nhất của VANS trong bộ sưu tập VANS OLD SKOOL ra đời năm 1977. Tới nay đôi giày chỉ với phối màu đen trắng này vẫn nằm trong top Best Seller của VANS trên toàn thế giới, với kiểu dáng cổ điển cùng sọc Jazz huyền thoại hợp thời trang khiến đôi VANS này thật sự trở thành mẫu giày classic bất bại, là fan hâm mộ của VANS nói chung và những skaters nói riêng đều nên có một đôi trong tủ giày. Được mệnh danh là phiên bản mang càng cũ càng đẹp và nhiều phiên bản custom  bậc nhất của nhà VANS. ",
                        img="sp33.jpg",
                        size="42",
                        status=1  
                    },
                    new Product{
                    product_id =34,
                        name="VANS CHECKERBOARD SLIP-ON CLASSIC BLACK/WHITE - VANS VIỆT NAM",
                        product_type_id=3,
                        amount=50,
                        price=1450000,
                        description=  "VANS CHECKERBOARD SLIP-ON CLASSIC BLACK/WHITE - VANS VIỆT NAM ",
                        img="sp34.jpg",
                        size="42",
                        status=1  
                    },
                    new Product{
                    product_id =35,
                        name="VANS CLASSIC SLIP-ON TRUE WHITE",
                        product_type_id=3,
                        amount=50,
                        price=1450000,
                        description=  "Là phiên bản trắng tinh True White nằm trong mục Best Seller của VANS và nằm trong bộ 3 True White mang lại lợi nhuận khổng lồ cho hãng. Được các họa sĩ Custom lựa chọn để cho ra những tác phẩm độc đáo vì chất liệu vải bố, đồng thời toàn đôi giày đều có thể vẽ lên bất cứ đâu. ",
                        img="sp35.jpg",
                        size="42",
                        status=1  
                    },
                    new Product{
                    product_id =36,
                        name="VANS CLASSIC OLD SKOOL NAVY/WHITE",
                        product_type_id=3,
                        amount=50,
                        price=1750000,
                        description=  "VANS CLASSIC OLD SKOOL NAVY/WHITE ",
                        img="sp36.jpg",
                        size="42",
                        status=1  
                    },
                    new Product{
                    product_id =37,
                        name="VANS FLAME SK8-HI REISSUE",
                        product_type_id=3,
                        amount=50,
                        price=1900000,
                        description=  "VANS FLAME SK8-HI REISSUE ",
                        img="sp37.jpg",
                        size="42",
                        status=1  
                    },
                    new Product{
                    product_id =38,
                        name="VANS CLASSIC SK8-HI NAVY/WHITE",
                        product_type_id=3,
                        amount=50,
                        price=1850000,
                        description=  "VANS CLASSIC SK8-HI NAVY/WHITE ",
                        img="sp38.jpg",
                        size="42",
                        status=1  
                    },
                    new Product{
                    product_id =39,
                        name="VANS CLASSIC AUTHENTIC BLACK/WHITE",
                        product_type_id=3,
                        amount=50,
                        price=1450000,
                        description=  "VANS CLASSIC AUTHENTIC BLACK/WHITE ",
                        img="sp39.jpg",
                        size="42",
                        status=1  
                    },
                    new Product{
                    product_id =40,
                        name="VANS CLASSIC AUTHENTIC TRUE WHITE",
                        product_type_id=3,
                        amount=50,
                        price=1450000,
                        description=  "VANS CLASSIC AUTHENTIC TRUE WHITE ",
                        img="sp40.jpg",
                        size="42",
                        status=1  
                    },
                    new Product{
                    product_id =41,
                        name="GIÀY OZWEEGO Cream White / Core Black / Screaming Orange",
                        product_type_id=4,
                        amount=50,
                        price=3100000,
                        description=  "Khi ngày mới kín đặc lịch trình, bạn không muốn phải bận tâm thêm bất kỳ điều gì nữa. Bạn cần sự thoải mái. Hãy để đôi giày adidas OZWEEGO này ra tay bằng cách giúp bạn khỏi lo hôm nay mặc gì. Tận hưởng cảm giác thoải mái ngay từ giây phút bạn bước ra khỏi cửa tới tận khi về nhà. Lớp đệm Adiprene và EVA giúp mỗi bước đi luôn dễ chịu. Với đôi giày này, không gì có thể cản bước bạn. ",
                        img="sp41.jpg",
                        size="42",
                        status=1  
                    },
                    new Product{
                    product_id =42,
                        name="GIÀY STAN SMITH Core White / Core White / Dark Blue",
                        product_type_id=4,
                        amount=50,
                        price=1150000,
                        description=  "GIÀY STAN SMITH Core White / Core White / Dark Blue ",
                        img="sp42.jpg",
                        size="42",
                        status=1  
                    },   
                    new Product{
                    product_id =43,
                        name="SLIPON PURE HM",
                        product_type_id=4,
                        amount=50,
                        price=4000000,
                        description=  "SLIPON PURE HM ",
                        img="sp43.jpg",
                        size="42",
                        status=1  
                    },   
                    new Product{
                    product_id =44,
                        name="SLIPON PURE HM White / Core White / Dark Blue",
                        product_type_id=4,
                        amount=50,
                        price=4000000,
                        description=  "SLIPON PURE HM White / Core White / Dark Blue ",
                        img="sp42.jpg",
                        size="42",
                        status=1  
                    },   
                    new Product{
                    product_id =45,
                        name="SLIPON PURE HM White / Core White / Dark Blue",
                        product_type_id=4,
                        amount=50,
                        price=4000000,
                        description=  "SLIPON PURE HM White / Core White / Dark Blue ",
                        img="sp45.jpg",
                        size="42",
                        status=1  
                    },   
                    new Product{
                    product_id =46,
                        name="SLIPON PURE HM White / Core White / Dark Blue",
                        product_type_id=4,
                        amount=50,
                        price=4000000,
                        description=  "GIÀY STAN SMITH Core White / Core White / Dark Blue ",
                        img="sp46.jpg",
                        size="42",
                        status=1  
                    },   
                    new Product{
                    product_id =47,
                        name="SLIPON PURE HM White / Core White / Dark Blue",
                        product_type_id=4,
                        amount=50,
                        price=4000000,
                        description=  "GIÀY STAN SMITH Core White / Core White / Dark Blue ",
                        img="sp47.jpg",
                        size="42",
                        status=1  
                    },
                    new Product{
                    product_id =48,
                        name="SLIPON PURE HM White / Core White / Dark Blue",
                        product_type_id=4,
                        amount=50,
                        price=3980000,
                        description=  "GIÀY STAN SMITH Core White / Core White / Dark Blue ",
                        img="sp48.jpg",
                        size="42",
                        status=1  
                    },   
                    new Product{
                    product_id =49,
                        name="SLIPON PURE HM White / Core White / Dark Blue",
                        product_type_id=4,
                        amount=50,
                        price=3990000,
                        description=  "GIÀY STAN SMITH Core White / Core White / Dark Blue ",
                        img="sp49.jpg",
                        size="42",
                        status=1  
                    },   
                    new Product{
                    product_id =50,
                        name="SLIPON PURE HM White / Core White / Dark Blue",
                        product_type_id=4,
                        amount=50,
                        price=3990000,
                        description=  "GIÀY STAN SMITH Core White / Core White / Dark Blue ",
                        img="sp50.jpg",
                        size="42",
                        status=1  
                    },   
                    new Product{
                    product_id =51,
                        name="SLIPON PURE HM White / Core White / Dark Blue",
                        product_type_id=4,
                        amount=50,
                        price=3990000,
                        description=  "GIÀY STAN SMITH Core White / Core White / Dark Blue ",
                        img="s51.jpg",
                        size="42",
                        status=1  
                    },   
                    new Product{
                    product_id =52,
                        name="SLIPON PURE HM White / Core White / Dark Blue",
                        product_type_id=4,
                        amount=50,
                        price=3980000,
                        description=  "GIÀY STAN SMITH Core White / Core White / Dark Blue ",
                        img="sp52.jpg",
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