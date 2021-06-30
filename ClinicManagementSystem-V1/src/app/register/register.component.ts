import { Component, OnInit } from '@angular/core';
import { ServiceService } from '../service.service';
import { ToastrService } from 'ngx-toastr';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
 
  showSuccessMessage:boolean;
  serverErrorMessage:string;

  constructor(public serviceService:ServiceService,
    public toastr:ToastrService,private router: Router) { }

  ngOnInit(): void {
  }

  onSubmit(form:NgForm){
    this.serviceService.postPatient(form.value).subscribe(
      x=>{
        this.showSuccessMessage=true;             
        setTimeout(()=>this.showSuccessMessage=false,5000);
        this.resetForm(form);

        this.router.navigate(['/login']);
      },);}

      
resetForm(form:NgForm){
  this.serviceService.selectedPatient={
  Name:'',
  Password:'',
  ConfirmPassword:'',
  Phone:'',
  Email:'',
  Address:'',
  BirthDate:new Date(),
  Gender:'',
  
  };
  form.resetForm();
  this.serverErrorMessage;
}

}
