import { Component, OnInit } from '@angular/core';
import { ServiceService } from '../service.service';

@Component({
  selector: 'app-patienthistory',
  templateUrl: './patienthistory.component.html',
  styleUrls: ['./patienthistory.component.css']
})
export class PatienthistoryComponent implements OnInit {

  data:any;
  constructor(private api:ServiceService) { }
  ngOnInit(): void {
  
    this.api.getbills().subscribe((data)=>{
      this.data=data;
        });
  }
}
