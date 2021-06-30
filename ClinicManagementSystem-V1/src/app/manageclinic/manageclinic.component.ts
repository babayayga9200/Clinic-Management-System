import { Component, OnInit } from '@angular/core';
import { ServiceService } from '../service.service';
import * as $AB from 'jquery';
import { event } from 'jquery';
@Component({
  selector: 'app-manageclinic',
  templateUrl: './manageclinic.component.html',
  styleUrls: ['./manageclinic.component.css']
})
export class ManageclinicComponent implements OnInit {
  showDeleteMessage:boolean;
  noDataToDisplay: boolean;
  p:number = 1;
 clickedUser:string='';
 doctor:any;
 patient:any;
 staff:any;
 ddoctor:any;
 dpatient:any;
 dstaff:any;
 DName:any;
 PName:any;
 SName:any;
 users: any=[
'Doctor',
'Patient',
'Other Staffs'
  ];

  radioChangeHandler(event:any){
    this.clickedUser=event.target.value;
    this.noDataToDisplay=false;
    console.log(this.clickedUser);
  }

  onSelectDoctor(id:number){
    this.api.getDoctorById(id).subscribe((doctor)=>{
      this.doctor=doctor;
      this.noDataToDisplay=false;
      console.log(doctor); 
        });
      
    (<any>$('#doctorModal')).modal('show');
    
    
  }

  SearchDoctor(){
       if(this.DName==""){
         this.ngOnInit();
         this.noDataToDisplay=false;
       }else{
         this.doctors=this.doctors.filter((result: { Name: string; }) =>{
          return result.Name.toLocaleLowerCase().match(this.DName.toLocaleLowerCase());
         })
       }
  }

  

  onDeleteDoctor(id:number){
    if(confirm("Do you want to delete this record?")){
    this.api.deleteDoctorById(id).subscribe((ddoctor)=>{
      this.ddoctor=ddoctor;
      this.noDataToDisplay=false;
      console.log(ddoctor); 
 
      this.showDeleteMessage=true;             
      setTimeout(()=>this.showDeleteMessage=false,5000);

      this.api.getDoctor().subscribe((doctors)=>{
      this.doctors=doctors;
      console.log(doctors); 


        });
        
      

        });  
      }
        
        
   
  }

  OnSelectPatient(id:number){
    this.api.getPatientById(id).subscribe((patient)=>{
      this.patient=patient;
      this.noDataToDisplay=false;
      
      console.log(patient); 
        });
        (<any>$('#patientModal')).modal('show');
  }

  SearchPatient(){
    if(this.PName==""){
      this.ngOnInit();
      this.noDataToDisplay=false;
    }else{
      this.patients=this.patients.filter((result: { Name: string; }) =>{
       return result.Name.toLocaleLowerCase().match(this.PName.toLocaleLowerCase());
      })
    }
}

  OnDeletePatient(id:number){
    if(confirm("Do you want to delete this record?")){
    this.api.deletePatientById(id).subscribe((dpatient)=>{
      this.dpatient=dpatient;
      this.noDataToDisplay=false;
      console.log(dpatient); 

      this.showDeleteMessage=true;             
      setTimeout(()=>this.showDeleteMessage=false,5000);

      this.api.getPatient().subscribe((patients)=>{
        this.patients=patients;
        console.log(patients); 
          });
        });     


          }
   
  }

  OnSelectStaff(id:number){
    this.api.getStaffById(id).subscribe((staff)=>{
      this.staff=staff;
      this.noDataToDisplay=false;
      console.log(staff); 
        });
        (<any>$('#staffModal')).modal('show');
  }
key:string;
reverse:boolean = false;
 sort(key:string){
   this.key=key;
   this.reverse=!this.reverse;
 }


  SearchStaff(){
    if(this.SName==""){
      this.ngOnInit();
      this.noDataToDisplay=false;
    }else{
      this.staffs=this.staffs.filter((result: { Name: string; }) =>{
       return result.Name.toLocaleLowerCase().match(this.SName.toLocaleLowerCase());
      })
    }
}

  
  OnDeleteConfirmation(){
    (<any>$('#confirmModal')).modal('show');
  }

  OnDeleteStaff(id:number){
    if(confirm("Are you sure to delete this record?")){
    this.api.deleteStaffById(id).subscribe((dstaff)=>{
      this.dstaff=dstaff;
      this.noDataToDisplay=false;
      console.log(dstaff); 

      this.showDeleteMessage=true;             
      setTimeout(()=>this.showDeleteMessage=false,5000);

      this.api.getStaff().subscribe((staffs)=>{
        this.staffs=staffs;
        console.log(staffs);
          });
        });  
        
        
    }

    


   
  }

  doctors:any=[];
  patients:any;
  staffs:any;
  constructor(private api:ServiceService) { }

  ngOnInit(): void {
    this.api.getDoctor().subscribe((doctors)=>{
      this.doctors=doctors;
      console.log(doctors); 
        });

        this.api.getPatient().subscribe((patients)=>{
          this.patients=patients;
          console.log(patients); 
            });

            this.api.getStaff().subscribe((staffs)=>{
              this.staffs=staffs;
              console.log(staffs); 
                });
                this.noDataToDisplay=true;
    

    
     
  }

}
function deptname(id: number) : string{
  if(id == 1)
  return "Cardiology"

  if(id == 2)
  return "Orthopaedics"

  if(id == 1)
  return "Ears Nose Throat"

  if(id == 1)
  return "Physiology"

  if(id == 1)
  return "Neurology"

  else
  return ""
}



