import { Component, OnInit } from '@angular/core';
import { CartService } from 'src/app/Services/cart.service';
import { ChiTietHoaDonService } from 'src/app/Services/chi-tiet-hoa-don.service';
import { HoaDonService } from 'src/app/Services/hoa-don.service';
import { CustomerService } from 'src/app/Services/khach-hang.service';
import Swal from 'sweetalert2';
import { DefaultComponent } from '../_shared/default/default.component';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.scss']
})
export class CartComponent implements OnInit {
  public SPforCart;
  public totalSP = 0;
  public totalCart = 0;

  public isAddress = "dcmacdinh";
  public address_thanhtoan = "";

  constructor(private httpCart : CartService, private defaultCome : DefaultComponent,
    private httpHD : HoaDonService, private httpKH : CustomerService, private httpCTHD : ChiTietHoaDonService) { }

  ngOnInit(): void {
    this.LoadSPforCart();
    
  }

  public LoadSPforCart() {
    var DonHang = localStorage.getItem("DonHang");
    if(DonHang == null || DonHang == "") {
      this.SPforCart = null;
      this.totalCart = 0;
      this.totalSP = 0;
      return;
    }

    this.httpCart.LoadSPForCart(DonHang).subscribe(data => {
      this.SPforCart = data;
      if(this.SPforCart != null) {
        this.totalSP = 0;
        this.totalCart = 0;
        this.SPforCart.forEach(element => {
          this.totalSP += element.amount;
          this.totalCart += element.price * element.amount;
        });
      }
    });
  }

  public dec_soluong(product_id : number) {
    var DonHang;
    DonHang = localStorage.getItem('DonHang');

    if(DonHang != null && DonHang != "") {
      if(DonHang.indexOf(product_id + '-') != -1) {

        var dauVa = DonHang.split("&");
        var dauNgang;

        for(let i = 0; i < dauVa.length - 1; ++i) {
          dauNgang = dauVa[i].split("-");

          if(Number(dauNgang[0]) == product_id) {
            var soluong = (Number(dauNgang[1]) - 1);
            if(soluong < 1) {
              soluong = 1;
            }
            dauVa[i] = product_id + "-" + soluong;
            break;
          }
        }

        DonHang = "";
        for(let i = 0; i < dauVa.length - 1; ++i) {
          DonHang += dauVa[i] + "&";
        }

        localStorage.setItem("DonHang", DonHang);
        this.LoadSPforCart(); 
        this.defaultCome.LoadSPforCart();
      }
      
    }
    
  }

  public inc_soluong(product_id : number) {
    var DonHang;
    DonHang = localStorage.getItem('DonHang');

    if(DonHang != null && DonHang != "") {
      if(DonHang.indexOf(product_id + '-') != -1) {

        var dauVa = DonHang.split("&");
        var dauNgang;

        for(let i = 0; i < dauVa.length - 1; ++i) {
          dauNgang = dauVa[i].split("-");
          if(Number(dauNgang[0]) == product_id) {
            dauVa[i] = product_id + "-" + (Number(dauNgang[1]) + 1);
            break;
          }
        }

        DonHang = "";
        for(let i = 0; i < dauVa.length - 1; ++i) {
          DonHang += dauVa[i] + "&";
        }

        localStorage.setItem("DonHang", DonHang);
        this.LoadSPforCart();
        this.defaultCome.LoadSPforCart();
      }
      
    }
  }

  public remove(product_id : number) {
    var DonHang;
    DonHang = localStorage.getItem('DonHang');

    if(DonHang != null && DonHang != "") {
      if(DonHang.indexOf(product_id + '-') != -1) {
        var dauVa = DonHang.split("&");
        var dauNgang;
        DonHang = "";

        for(let i = 0; i < dauVa.length - 1; ++i) {
          dauNgang = dauVa[i].split("-");
          if(Number(dauNgang[0]) == product_id) {
            continue;
          }
          DonHang += dauNgang[0] + '-' + dauNgang[1] + '&';
        }

        localStorage.setItem("DonHang", DonHang);
        this.LoadSPforCart();
        this.defaultCome.LoadSPforCart();
      }
    }
  }

  public CheckOutCart() {
    
    // Ki???m tra c?? danh s??ch s???n ph???m trong ????n h??ng kh??ng
    var DonHang = localStorage.getItem('DonHang');
    if(DonHang == null || DonHang == "") {
      Swal.fire({
        type : "error",
        title : "????n h??ng r???ng!!!",
        html : "Thanh to??n th???t b???i!!!"
      });
      return;
    }

    // Ki???m tra ???? ????ng nh???p ch??a 
    var CurrentUser = sessionStorage.getItem("CurrentUser");
    CurrentUser = JSON.parse(CurrentUser);

    if(CurrentUser == null || CurrentUser == "") {
      Swal.fire({
        type : "error",
        title : "B???n ch??a ????ng nh???p!!!",
        html : "Thanh to??n th???t b???i!!!"
      }).then(result => {
        location.href = window.location.origin + "/login";
      });
    }

    // L???y th??ng tin kh??ch h??ng
    var KH;
    this.httpKH.getKH(CurrentUser['user']).subscribe(data => {
      if(data){
        KH = data;

        // C???p nh???t ?????a ch??? thanh to??n
        if(this.isAddress == "diachi") {
          if(this.address_thanhtoan == "") {
            Swal.fire({
              type : "error",
              title : "?????a ch??? thanh to??n ch??a c???p nh???t!!!"
            })
          }
          return;
        }
        else {
          this.address_thanhtoan = KH.address;
        }

        // L???y ID h??a ????n
        this.httpHD.GetMaxId().subscribe(data => {
          const HD = {
            bill_id : (data + 1),
            user_kh : KH.user,
            user_nv : null,
            phone : KH.phone,
            address : this.address_thanhtoan,
            date_receice : null,
            date_order : null,
            total : this.totalCart,
            status : 1
          };

          // C???p nh???t h??a ????n
          this.httpHD.AddHD(HD).subscribe(data => {
            if(data) {
              const cthd = {
                bill_id : data.bill_id,
                list : DonHang
              };

              this.httpCTHD.AddCTHDRange(cthd).subscribe(data => {
                Swal.fire({
                  type : "success",
                  title : "Thanh to??n th??nh c??ng!!!"                
                }).then(result => {
                  DonHang = "";
                  localStorage.removeItem("DonHang");
                  location.reload();
                });
              }, error => {
                Swal.fire({
                  type : "error",
                  title : "Thanh to??n th???t b???i!!!",
                  html : error.responseText
                });
              });
            }
            else {
              Swal.fire({
                type : "error",
                title : "L???i th??m h??a ????n!!! 1"
              });
            }
          }, error => {
            Swal.fire({
              type : "error",
              title : "L???i th??m h??a ????n!!! 2",
              html : error.responseText
            })
          });
        });
      }
      else {
        Swal.fire({
          type : "error",
          title : "L???i l???y th??ng tin kh??ch h??ng th???t b???i!!!"
        })
      }
    }, error => {
      Swal.fire({
        type : "error",
        title : "L???i l???y th??ng tin kh??ch h??ng th???t b???i!!!",
        html : error.responseText
      })
    }); 
    
  }

  // public chang_address(aa) {
  //   alert(aa.value);
  // }
}
