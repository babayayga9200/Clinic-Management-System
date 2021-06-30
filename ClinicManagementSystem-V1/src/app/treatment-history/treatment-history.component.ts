import { Component, OnInit } from '@angular/core';
import {ServiceService } from '../service.service';

@Component({
  selector: 'app-treatment-history',
  templateUrl: './treatment-history.component.html',
  styleUrls: ['./treatment-history.component.css']
})
export class TreatmentHistoryComponent implements OnInit {

  Patient_History :any;
  constructor(private api:ServiceService) { }

  ngOnInit(): void {
    this.api. getBillDetailsById(10).subscribe((Patient_History)=>{
    this.Patient_History=Patient_History;
    console.log(Patient_History); 
   });
  }

}
