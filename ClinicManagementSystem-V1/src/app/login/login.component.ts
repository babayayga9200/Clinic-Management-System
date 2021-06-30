// import { Component, OnInit } from '@angular/core';

// @Component({
//   selector: 'app-login',
//   templateUrl: './login.component.html',
//   styleUrls: ['./login.component.css']
// })
// export class LoginComponent implements OnInit {

//   constructor() { }

//   ngOnInit(): void {
//   }

// }

import { Component, OnInit } from '@angular/core';
import { ServiceService } from '.././service.service';
import { HttpErrorResponse } from '@angular/common/http';
import { Router } from '@angular/router';



@Component({
    selector: 'app-login',
    templateUrl: './login.component.html',
    styleUrls: ['./login.component.css']
   })
export class LoginComponent implements OnInit {

  isLoginError : boolean = false;
  constructor(private userService : ServiceService,private router : Router) { }

  ngOnInit() {
  }

  OnSubmit(userName: any,password: any){
     this.userService.userAuthentication(userName,password).subscribe((data : any)=>{
      localStorage.setItem('userToken',data.access_token);
      localStorage.setItem('userRoles',data.role);
      if(this.userService.roleMatch(["1"]))
      this.router.navigate(['/adminhome']);
      if(this.userService.roleMatch(["2"]))
      this.router.navigate(['/doctordetails']);
      if(this.userService.roleMatch(["3"]))
      this.router.navigate(['/patient-view']);

    },
    (err : HttpErrorResponse)=>{
      this.isLoginError = true;
    });
  }
  
  

}

