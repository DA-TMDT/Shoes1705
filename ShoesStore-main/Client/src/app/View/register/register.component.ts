import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { CustomerService } from 'src/app/Services/khach-hang.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {
  public profileUserForm = new FormGroup({
    user : new FormControl('', Validators.compose([
      Validators.required,
      Validators.minLength(3),
      Validators.maxLength(20),
      Validators.pattern("^[\\w]+$")
    ])),
    pass: new FormControl('', Validators.compose([
      Validators.required,
      Validators.minLength(4),
      Validators.maxLength(20),
      // Validators.pattern("[^!@#$%^&*()_+\-=\[\]{};':\"\\|,.<>\/?]")
    ])),
    repass : new FormControl('', Validators.compose([
      Validators.required
    ])),
    full_name : new FormControl('', Validators.compose([
      Validators.required,
      Validators.minLength(2),
      Validators.maxLength(60)
    ])),
    phone : new FormControl('', Validators.compose([
      Validators.required,
      Validators.minLength(10),
      Validators.maxLength(11),
      Validators.pattern("^[\\d]+$")
    ])),
    mail : new FormControl('', Validators.compose([
      Validators.required,
      Validators.pattern("^[_A-Za-z0-9-\\+]+(\\.[_A-Za-z0-9-]+)*@[A-Za-z0-9-]+(\\.[A-Za-z0-9]+)*(\\.[A-Za-z]{2,})$")
    ])),
    address : new FormControl('', Validators.compose([
      Validators.required
    ])),
    sex : new FormControl('Nam', Validators.compose([
      Validators.required
    ])),
    dateborn : new FormControl('', Validators.compose([
      Validators.required
    ])),
    status : new FormControl('1')
  });
  constructor(private registerHttp : CustomerService) { }

  ngOnInit(): void {
  }

  public addUser() {
    const newProfileUser = {};
    newProfileUser["user"] = this.profileUserForm.controls["user"].value;
    newProfileUser["pass"] = this.profileUserForm.controls["pass"].value;
    newProfileUser["repass"] = this.profileUserForm.controls["repass"].value;
    newProfileUser["full_name"] = this.profileUserForm.controls["full_name"].value;
    newProfileUser["phone"] = this.profileUserForm.controls["phone"].value;
    newProfileUser["mail"] = this.profileUserForm.controls["mail"].value;
    newProfileUser["address"] = this.profileUserForm.controls["address"].value;
    newProfileUser["sex"] = this.profileUserForm.controls["sex"].value;
    newProfileUser["dateborn"] = this.profileUserForm.controls["dateborn"].value;
    newProfileUser["status"] = this.profileUserForm.controls["status"].value;

    this.registerHttp.AddKH_Register(newProfileUser).subscribe(data => {
      console.log("Register - AddUser: ", data);
      if(data) {
        sessionStorage.setItem("CurrentUser", JSON.stringify(data));
        Swal.fire({
          type : "success",
          title : "????ng k?? th??nh c??ng!",
          text : "Ch??o " + data.full_name
        }).then((result) => {
          location.reload();
        });
      }
      else {
        Swal.fire({
          type : "error",
          title : "????ng k?? th???t b???i!"
        });
      }
    });
    // console.log("user: " , this.profileUserForm.controls["user"].errors);
    // console.log("pass: " , this.profileUserForm.controls["pass"].errors);
    // console.log("repass: " , this.profileUserForm.controls["repass"].errors);
    // console.log("full_name: " , this.profileUserForm.controls["full_name"].errors);
    // console.log("phone: " , this.profileUserForm.controls["phone"].errors);
    // console.log("mail: " , this.profileUserForm.controls["mail"].errors);
    // console.log("address: " , this.profileUserForm.controls["address"].errors);
    // console.log("sex: " , this.profileUserForm.controls["sex"].errors);
    // console.log("dateborn: " , this.profileUserForm.controls["dateborn"].errors);
    // console.log("status: " , this.profileUserForm.controls["status"].errors);
    // console.log("profile: ", this.profileUserForm.valid);
    // alert("waite");
  }

  // L???i User
  public getErrorUser() {
    const user = this.profileUserForm.controls["user"];
    if(user.untouched) {
      return "";
    }

    if(user.errors == null) {
      return "";
    }
    // C?? l???i required
    if(user.errors.required != null) {
      return "T??i kho???n l?? b???t bu???c";
    }

    // C?? l???i chi???u d??i
    if(user.errors.minlength != null || user.errors.maxlength != null) {
      return "T??i kho???n t??? 3 ?????n 20 k?? t???";
    }

    // C?? l???i pattern
    // console.log("Pattern: " + JSON.stringify(user.errors.pattern));
    if(user.errors.pattern) {
      return "T??i kho???n l?? c??c k?? t??? ch??? v?? s???";
    }
  }

  // L???i Password
  public getErrorPass() {
    const pass = this.profileUserForm.controls["pass"];
    if(pass.untouched) {
      return "";
    }

    if(pass.errors == null) {
      return "";
    }
    // C?? l???i required
    if(pass.errors.required != null) {
      return "M???t kh???u l?? b???t bu???c";
    }

    // C?? l???i chi???u d??i
    if(pass.errors.minlength != null || pass.errors.maxlength != null) {
      return "M???t kh???u t??? 4 ?????n 20 k?? t???";
    }
  }

  // L???i Repass
  public getErrorRepass() {
    const repass = this.profileUserForm.controls["repass"];
    if(repass.untouched) {
      return "";
    }

    if(repass.value != this.profileUserForm.controls["pass"].value) {
      repass.setErrors({pattern: true});
      return "M???t kh???u kh??ng tr??ng kh???p!";
    }

    if(repass.errors == null) {
      return "";
    }
    // C?? l???i required
    if(repass.errors.required != null) {
      return "M???t kh???u l?? b???t bu???c";
    }
    
  }

  // L???i Password
  public getErrorFull_name() {
    const full_name = this.profileUserForm.controls["full_name"];
    if(full_name.untouched) {
      return "";
    }

    if(full_name.errors == null) {
      return "";
    }
    // C?? l???i required
    if(full_name.errors.required != null) {
      return "H??? t??n l?? b???t bu???c";
    }

    // C?? l???i chi???u d??i
    if(full_name.errors.minlength != null || full_name.errors.maxlength != null) {
      return "H??? t??n t??? 2 ?????n 60 k?? t???";
    }
  }

  public getErrorPhone() {
    const phone = this.profileUserForm.controls["phone"];
    if(phone.untouched) {
      return "";
    }

    if(phone.errors == null) {
      return "";
    }
    // C?? l???i required
    if(phone.errors.required != null) {
      return "S??? ??i???n tho???i l?? b???t bu???c";
    }

    // C?? l???i chi???u d??i
    if(phone.errors.minlength != null || phone.errors.maxlength != null) {
      return "S??? ??i???n tho???i t??? 10 ?????n 11 k?? t???";
    }

    // C?? l???i pattern
    if(phone.errors.pattern) {
      return "S??? ??i???n tho???i l?? c??c k?? t??? s???";
    }
  }

  public getErrorMail() {
    const mail = this.profileUserForm.controls["mail"];
    if(mail.untouched) {
      return "";
    }

    if(mail.errors == null) {
      return "";
    }
    // C?? l???i required
    if(mail.errors.required != null) {
      return "Th?? ??i???n t??? l?? b???t bu???c";
    }

    // C?? l???i pattern
    if(mail.errors.pattern) {
      return "L???i ?????nh d???nh mail!";
    }
  }

  public getErrorAddress() {
    const address = this.profileUserForm.controls["address"];
    if(address.untouched) {
      return "";
    }

    if(address.errors == null) {
      return "";
    }
    // C?? l???i required
    if(address.errors.required != null) {
      return "?????a ch??? l?? b???t bu???c";
    }
  }

  public getErrorSex() {
    const sex = this.profileUserForm.controls["sex"];
    if(sex.untouched) {
      return "";
    }

    if(sex.errors == null) {
      return "";
    }
    // C?? l???i required
    if(sex.errors.required != null) {
      return "Gi???i t??nh l?? b???t bu???c";
    }
  }

  public getErrorDateBorn() {
    const dateborn = this.profileUserForm.controls["dateborn"];
    if(dateborn.untouched) {
      return "";
    }

    if(dateborn.errors == null) {
      return "";
    }
    // C?? l???i required
    if(dateborn.errors.required != null) {
      return "Ng??y sinh l?? b???t bu???c";
    }
  }

  public changeSex(sss) {
    this.profileUserForm.controls["sex"].setValue(sss);
  }
}
