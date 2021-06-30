import { Component, OnInit } from '@angular/core';
import { ServiceService } from '../service.service';
import * as $AB from 'jquery';
import { event } from 'jquery';
import { Router, RouterModule, Routes } from '@angular/router';

@Component({
  selector: 'app-doctordetails',
  templateUrl: './doctordetails.component.html',
  styleUrls: ['./doctordetails.component.css']
})
export class DoctordetailsComponent implements OnInit {
  public clickedUser:string='';
  public doctor:any;
  public patient:any;
  public staff:any;
  public ddoctor:any;
  public dpatient:any;
  public dstaff:any;
   
   radioChangeHandler(event:any){
     this.clickedUser=event.target.value;
     console.log(this.clickedUser);
   }
 
   onSelectDoctor(id:number){
     this.api.getDoctorById(id).subscribe((doctor)=>{
       this.doctor=doctor;
       console.log(doctor); 
         });
       
     (<any>$('#doctorModal')).modal('show');
     
     
   }
 
   onDeleteDoctor(id:number){
     this.api.deleteDoctorById(id).subscribe((ddoctor)=>{
       this.ddoctor=ddoctor;
       console.log(ddoctor); 
 
       this.api.getDoctor().subscribe((doctors)=>{
       this.doctors=doctors;
       console.log(doctors); 
       alert("Page refreshing")
         });
         
  
 
         });  
         
         
    
   }
 
   OnSelectPatient(id:number){
     this.api.getPatientById(id).subscribe((patient)=>{
       this.patient=patient;
       console.log(patient); 
         });
         (<any>$('#patientModal')).modal('show');
   }
 
   OnDeletePatient(id:number){
     this.api.deletePatientById(id).subscribe((dpatient)=>{
       this.dpatient=dpatient;
       console.log(dpatient); 
         });     
 
         this.api.getPatient().subscribe((patients)=>{
           this.patients=patients;
           console.log(patients); 
             });
    
   }
 
   OnSelectStaff(id:number){
     this.api.getStaffById(id).subscribe((staff)=>{
       this.staff=staff;
       console.log(staff); 
         });
         (<any>$('#staffModal')).modal('show');
   }
 
   OnDeleteStaff(id:number){
     this.api.deleteStaffById(id).subscribe((dstaff)=>{
       this.dstaff=dstaff;
       console.log(dstaff); 
         });  
         
         this.api.getStaff().subscribe((staffs)=>{
           this.staffs=staffs;
           console.log(staffs); 
           alert("Page refreshing")
             });
 
 
    
   }
 
   doctors:any;
   patients:any;
   staffs:any;
   constructor(private api:ServiceService) { }
 
  ngOnInit(): void {
   
      this.api.getDoctorById(35).subscribe((doctors)=>{
        this.doctors=doctors;
        console.log(doctors); 
          });

   
  }

}
