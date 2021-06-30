// import { Component, OnInit } from '@angular/core';
// import {ServiceService} from '../service.service'; 
// import { stringify } from '@angular/compiler/src/util';
// import * as $AB from 'jquery';
// import { event } from 'jquery';

// @Component({
//   selector: 'app-take-appointment',
//   templateUrl: './take-appointment.component.html',
//   styleUrls: ['./take-appointment.component.css']
// })
// export class TakeAppointmentComponent implements OnInit {    

//     ClickedDepartment:Number=0;
    
  
//     radioChangeHandler(event:any){
//       this.ClickedDepartment=event.target.value;
//       console.log(this.ClickedDepartment);
//     }
  
    
//     doctor:any; //select by id
  
  
//     onSelectDoctor(id:number){
//       this.api.getDoctorById(id).subscribe((doctor)=>{
//         this.doctor=doctor;
//         console.log(doctor); 
//           });
        
//       (<any>$('#doctorModal')).modal('show');      
      
//     }
//     doctor_By_Cardio:any;
//     doctor_By_Ortho:any;
//     doctor_By_Ent:any;
//     doctor_By_Physio:any; 
//     doctor_By_Neuro:any
  
        
//     constructor (private api : ServiceService) {}
    
//     ngOnInit(): void {
//       this.api.GetDoctor_ByDeptId(1).subscribe((doctor_By_Cardio)=>{
//       this.doctor_By_Cardio=doctor_By_Cardio;
//       console.log(doctor_By_Cardio); 
//       });
//       this.api.GetDoctor_ByDeptId(2).subscribe((doctor_By_Ortho)=>{
//       this.doctor_By_Ortho=doctor_By_Ortho;
//       console.log(doctor_By_Ortho); 
//        });
//       this.api.GetDoctor_ByDeptId(3).subscribe((doctor_By_Ent)=>{
//       this.doctor_By_Ent=doctor_By_Ent;
//       console.log(doctor_By_Ent); 
//       });
//       this.api.GetDoctor_ByDeptId(4).subscribe((doctor_By_Physio)=>{
//       this.doctor_By_Physio=doctor_By_Physio;
//       console.log(doctor_By_Physio); 
//       });
//       this.api.GetDoctor_ByDeptId(5).subscribe((doctor_By_Neuro)=>{
//       this.doctor_By_Neuro=doctor_By_Neuro;
//       console.log(doctor_By_Neuro); 
//        });
//     }
// }



// *********************************************************************************************************************
import { Component, OnInit } from '@angular/core';
import {ServiceService} from '../service.service';
import { stringify } from '@angular/compiler/src/util';
import { NgForm, ReactiveFormsModule } from '@angular/forms';
import * as $AB from 'jquery';
import { event } from 'jquery';

@Component({
  selector: 'app-take-appointment',
  templateUrl: './take-appointment.component.html',
  styleUrls: ['./take-appointment.component.css'],
  providers:[ServiceService]
})
export class TakeAppointmentComponent implements OnInit {   
  showSuccessMessage:boolean=true;
  serverErrorMessage:string='';


    ClickedDepartment:Number=0;
    
  
    radioChangeHandler(event:any){
      this.ClickedDepartment=event.target.value;
      console.log(this.ClickedDepartment);
    }
  
    
    doctor:any; //select by id
    
    onSelectDoctor(id:number){
      this.api.getDoctorById(id).subscribe((doctor: any)=>{
        this.doctor=doctor;
        console.log(doctor); 
          });
        
      (<any>$('#doctorModal')).modal('show');      
      
    }

    onSubmit(form:NgForm){
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
        DOA: new Date()
      };
      form.resetForm();
      this.serverErrorMessage;
    }
    onAppointment(DocId:number,date:Date ){
      this.api.selectedAppointment.DoctorId=DocId,
      this.api.selectedAppointment.PatientId=1,
      this.api.selectedAppointment.DOA=date
    }
    doctor_By_Cardio:any;
    doctor_By_Ortho:any;
    doctor_By_Ent:any;
    doctor_By_Physio:any; 
    doctor_By_Neuro:any
  
    
        
    constructor (public api : ServiceService) {}
    
    ngOnInit(): void {
      this.api.GetDoctor_ByDeptId(1).subscribe((doctor_By_Cardio: any)=>{
      this.doctor_By_Cardio=doctor_By_Cardio;
      console.log(doctor_By_Cardio); 
      });
      this.api.GetDoctor_ByDeptId(2).subscribe((doctor_By_Ortho: any)=>{
      this.doctor_By_Ortho=doctor_By_Ortho;
      console.log(doctor_By_Ortho); 
       });
      this.api.GetDoctor_ByDeptId(3).subscribe((doctor_By_Ent: any)=>{
      this.doctor_By_Ent=doctor_By_Ent;
      console.log(doctor_By_Ent); 
      });
      this.api.GetDoctor_ByDeptId(4).subscribe((doctor_By_Physio: any)=>{
      this.doctor_By_Physio=doctor_By_Physio;
      console.log(doctor_By_Physio); 
      });
      this.api.GetDoctor_ByDeptId(5).subscribe((doctor_By_Neuro: any)=>{
      this.doctor_By_Neuro=doctor_By_Neuro;
      console.log(doctor_By_Neuro); 
       });
    }


    // onAppointment(DocId:number,date:Date ){
    //   this.api.selectedAppointment.DoctorId=DocId,
    //   this.api.selectedAppointment.PatientId=1,
    //   this.api.selectedAppointment.DOA=
    // }
}