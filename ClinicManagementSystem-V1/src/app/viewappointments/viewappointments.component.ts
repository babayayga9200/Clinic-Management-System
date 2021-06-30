import { Component, OnInit } from '@angular/core';
import { ServiceService } from '../service.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-viewappointments',
  templateUrl: './viewappointments.component.html',
  styleUrls: ['./viewappointments.component.css']
})

export class ViewappointmentsComponent implements OnInit {

  constructor(private api:ServiceService, public router :Router){

 

   }
   
   data:any;
   aapoint:any;
   onDeleteAppointment(id:number){
    if(confirm("Do you want to delete this record?")){
      this.api.deleteAppointmentById(id).subscribe((aapoint)=>{
        this.aapoint=this.aapoint;
      
        
  
      this.api.getAcceptedAppointmentst().subscribe((data)=>{
      this.data=data; 
          });
        
       });  
      }  
  }
 
  ngOnInit(): void {
    
    this.api.getAcceptedAppointmentst().subscribe((data)=>{
      this.data=data;
        });
  }

}
