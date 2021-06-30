import { Component, OnInit } from '@angular/core';
import {ServiceService} from '../service.service';
import { DatePipe } from '@angular/common';
@Component({
  selector: 'app-patient-view',
  templateUrl: './patient-view.component.html',
  styleUrls: ['./patient-view.component.css']
})
export class PatientViewComponent implements OnInit {
  patient:any;  
  

  constructor(private api:ServiceService,public datePipe: DatePipe) { }

  ngOnInit(): void {
    this.api.getPatientById(20).subscribe((patient: any)=>{
      this.patient=patient;
      console.log(patient); 
        });

        console.log(this.api.login());
  }

}


