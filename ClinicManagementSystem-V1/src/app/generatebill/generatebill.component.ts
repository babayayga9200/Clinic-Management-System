import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ServiceService } from '../service.service';

@Component({
  selector: 'app-generatebill',
  templateUrl: './generatebill.component.html',
  styleUrls: ['./generatebill.component.css'],
  providers:[ServiceService]
})
export class GeneratebillComponent implements OnInit {
  showSuccessMessage:boolean;
  serverErrorMessage:string;
  constructor(public serviceService:ServiceService) { }

  ngOnInit(): void {
  }

  onSubmit(form:NgForm){
    this.serviceService.postBill(form.value).subscribe(
      x=>{
        this.showSuccessMessage=true;
        setTimeout(()=>this.showSuccessMessage=false,5000);
        this.resetForm(form);
      },);}

      resetForm(form:NgForm){
        this.serviceService.selectedBill={
              Date:new Date(),
              PatientName:'',
              DoctorName:'',
              Amount:new Number(),
              Prescription:'',
              PurposeOfVisit:''
        };
        form.resetForm();
        this.serverErrorMessage;
      }

}
