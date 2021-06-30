import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ServiceService } from '../service.service';

@Component({
  selector: 'app-addstaff',
  templateUrl: './addstaff.component.html',
  styleUrls: ['./addstaff.component.css'],
  providers:[ServiceService]
})
export class AddstaffComponent implements OnInit {

  showSuccessMessage:boolean;
  serverErrorMessage:string;
  constructor(public serviceService:ServiceService) { }

  ngOnInit(): void {
  }

  onSubmit(form:NgForm){
    this.serviceService.postStaff(form.value).subscribe(
      x=>{
        this.showSuccessMessage=true;
        setTimeout(()=>this.showSuccessMessage=false,5000);
        this.resetForm(form);
      },);}

      resetForm(form:NgForm){
        this.serviceService.selectedStaff={
          Name:'',
          Password:'',
          ConfirmPassword:'',
          Email:'',
          Phone:'',
          Address:'',
          BirthDate:new Date(),
          Department:'',
          Salary:new Number(),
          Highest_Qualification:'',
          Designation:''
        };
        form.resetForm();
        this.serverErrorMessage;
      }
}
