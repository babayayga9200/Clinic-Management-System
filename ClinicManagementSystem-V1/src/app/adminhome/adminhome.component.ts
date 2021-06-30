import { DatePipe } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { ServiceService } from '../service.service';
import { Router, RouterModule, Routes } from '@angular/router';

@Component({
  selector: 'app-adminhome',
  templateUrl: './adminhome.component.html',
  styleUrls: ['./adminhome.component.css']
})
export class AdminhomeComponent implements OnInit {

    constructor(private api:ServiceService,
    public datePipe: DatePipe,
    private router:Router) { 

  }

  doctors:any;
  data:any;

  appointment:any;

  items:string[];

  public patient:any;

  docCount:any;

  income:any;

  

  ngOnInit(): void {
    this.api.getDepartmentInformation().subscribe((data)=>{
      this.data=data;
    });

    this.api.getDoctor().subscribe((doctors)=>{
      this.doctors=doctors;
        });

    this.api.getDoctorCount().subscribe((docCount)=>{
    this.docCount=docCount;
  });

  this.api.getAppointment().subscribe(appointment=>{
    this.appointment=appointment;
  });

  this.api.getPatientCount().subscribe((patient)=>{
    this.patient=patient;
  });

 this.api.getTotalIncome().subscribe((income)=>{
   this.income=income;
 });

 
}


}
