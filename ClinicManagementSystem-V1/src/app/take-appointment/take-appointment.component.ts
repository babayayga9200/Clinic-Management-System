import { Component, ViewChild, ElementRef,OnInit } from '@angular/core';
import {ServiceService} from '../service.service';
import { stringify } from '@angular/compiler/src/util';
import { NgForm, FormBuilder, NgModel, ReactiveFormsModule } from '@angular/forms';
import * as $AB from 'jquery';
import { event } from 'jquery';
import { empty } from 'rxjs';
import { Appointment } from '../appointment';

@Component({
  selector: 'app-take-appointment',
  templateUrl: './take-appointment.component.html',
  styleUrls: ['./take-appointment.component.css'],
  providers:[ServiceService]
})
export class TakeAppointmentComponent implements OnInit {   
  showSuccessMessage:boolean=true;
  serverErrorMessage:string='';
  Appdate:Date;
  @ViewChild("Appoint") myNameElem: ElementRef;
    ClickedDepartment:Number=0;
    docID:number;
    appointDate:Date;
    a:Appointment={
      DoctorId:0,
      PatientId:0,
      Date:new Date()
    };

    

    bookAppointment(){
      console.log(this.docID);

        this.a.DoctorId=this.doctor[0].DoctorID;
        this.a.PatientId=this.api.login();
        this.a.Date=this.myNameElem.nativeElement.value;
        console.log(this.a);

        this.api.postAppointment(this.a).subscribe(
          x=>{
            this.showSuccessMessage=true;
            setTimeout(()=>this.showSuccessMessage=false,5000);            
          },
        );
        
    }

    
  
    radioChangeHandler(event:any){
      this.ClickedDepartment=event.target.value;
    }
  
    
    doctor:any; //select by id
    
    onSelectDoctor(id:number){
      this.api.getDoctorById(id).subscribe((doctor: any)=>{
        this.doctor=doctor;
          });
        
      (<any>$('#doctorModal')).modal('show');      
      
    }

    onSubmit(form:NgForm){
      this.appointDate=form.value;
      
      this.api.postAppointment(form.value).subscribe(
        x=>{
          this.showSuccessMessage=true;
          setTimeout(()=>this.showSuccessMessage=false,5000);
          this.resetForm(form);
        },
      );
    }
    resetForm (form:NgForm){
      this.api.selectedAppointment={
        DoctorId : 0,
        PatientId:0,
        Date: new Date()
      };
      form.resetForm();
      this.serverErrorMessage;
    }
    onAppointment(DocId:number,date:Date ){
      this.api.selectedAppointment.DoctorId=DocId,
      this.api.selectedAppointment.PatientId=1,
      this.api.selectedAppointment.Date=date
    }
    doctor_By_Cardio:any;
    doctor_By_Ortho:any;
    doctor_By_Ent:any;
    doctor_By_Physio:any; 
    doctor_By_Neuro:any
  
    
        
    constructor (public api : ServiceService, private formBuilder: FormBuilder) {}
    
    ngOnInit(): void {
      this.Appdate = new Date();
      // this.appointmentForm = this.formBuilder.group({Appdate : ""});

      this.api.GetDoctor_ByDeptId(1).subscribe((doctor_By_Cardio: any)=>{
      this.doctor_By_Cardio=doctor_By_Cardio;
      });
      this.api.GetDoctor_ByDeptId(2).subscribe((doctor_By_Ortho: any)=>{
      this.doctor_By_Ortho=doctor_By_Ortho;
       });
      this.api.GetDoctor_ByDeptId(3).subscribe((doctor_By_Ent: any)=>{
      this.doctor_By_Ent=doctor_By_Ent;
      });
      this.api.GetDoctor_ByDeptId(4).subscribe((doctor_By_Physio: any)=>{
      this.doctor_By_Physio=doctor_By_Physio;
      });
      this.api.GetDoctor_ByDeptId(5).subscribe((doctor_By_Neuro: any)=>{
      this.doctor_By_Neuro=doctor_By_Neuro;
       });
    }


    
}