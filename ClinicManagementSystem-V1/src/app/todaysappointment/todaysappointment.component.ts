import { Component, OnInit } from '@angular/core';
import { ServiceService } from '../service.service';

@Component({
  selector: 'app-todaysappointment',
  templateUrl: './todaysappointment.component.html',
  styleUrls: ['./todaysappointment.component.css']
})
export class TodaysappointmentComponent implements OnInit {

  constructor(private api:ServiceService) {

   }
   showDeleteMessage:boolean;
   data:any;
   aapoint:any;
   onDeleteAppointment(id:number){
    if(confirm("Do you want to delete this record?")){
      this.api.deleteAppointmentById(id).subscribe((aapoint)=>{
        this.aapoint=this.aapoint;
        console.log(this.aapoint);
      
        this.showDeleteMessage=true;             
        setTimeout(()=>this.showDeleteMessage=false,5000);
  
      this.api.getUnAcceptedAppointmentst().subscribe((data)=>{
      this.data=data;
      console.log(data); 
          });
        
       });  
      }  
  }
  onAcceptedAppointment(id:number){
    if(confirm("Do you want to Accept this Appointment?"))
    this.api.putAcceptedAppointment(id).subscribe((data)=>{
      this.data = this.data;
      console.log(this.data);

      
      this.api.getUnAcceptedAppointmentst().subscribe((data)=>{
        this.data=data;
        console.log(data); 
            });

    });
  }
  ngOnInit(): void {
    
    this.api.getUnAcceptedAppointmentst().subscribe((data)=>{
      this.data=data;
      console.log(data);
        });
  }

}
