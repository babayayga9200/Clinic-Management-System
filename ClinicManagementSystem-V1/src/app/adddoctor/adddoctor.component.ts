import { Component, OnInit } from '@angular/core';
import { NgForm, ReactiveFormsModule } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { ServiceService } from '../service.service';
@Component({
  selector: 'app-adddoctor',
  templateUrl: './adddoctor.component.html',
  styleUrls: ['./adddoctor.component.css'],
  providers:[ServiceService]
})
export class AdddoctorComponent implements OnInit {
  showSuccessMessage:boolean;
  serverErrorMessage:string;

  constructor(public serviceService:ServiceService,
            public toastr:ToastrService) { 
    
  }
 
  ngOnInit(): void {
  }

  onSubmit(form:NgForm){
    this.serviceService.postDoctor(form.value).subscribe(
      x=>{
        this.showSuccessMessage=true;             
        setTimeout(()=>this.showSuccessMessage=false,5000);
        this.resetForm(form);
      },);}


      
  resetForm(form:NgForm){
    this.serviceService.selectedUser={
    Name:'',
    Password:'',
    ConfirmPassword:'',
    Phone:'',
    Email:'',
    Address:'',
    BirthDate:new Date(),
    Gender:'',
    Department:'',
    Charges_Per_Visit:0,
    MonthlySalary:0.00,
    Patients_Treated:0,
    Qualification:'',
    Specialization:'',
    Work_Experience:0,
    Deptname:''
    };
    form.resetForm();
    this.serverErrorMessage;
  }

}
