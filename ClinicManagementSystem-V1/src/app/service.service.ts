import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Doctor } from './doctor';
import { Staff } from './staff';
import { Bill} from './bill';
import 'rxjs/add/operator/map';
import { Patient } from './patient';
import { Appointment } from './appointment';
@Injectable({
  providedIn: 'root'
})
export class ServiceService {
  loginid:number;
  selectedUser:Doctor ={
    Name:'',
    Password:'',
    ConfirmPassword:'',
    Phone:'',
    Email:'',
    Address:'',
    BirthDate:new Date(),
    Gender:'',
    Department:'',
    Charges_Per_Visit:0,
    MonthlySalary:0.00,
    Patients_Treated:0,
    Qualification:'',
    Specialization:'',
    Work_Experience:0,
    Deptname:''
  };

  selectedBill : Bill={
     Date:new Date(),
     PatientName:'',
     DoctorName:'',
     Amount:new Number(),
     Prescription:'',
     PurposeOfVisit:''
  };

  selectedStaff:Staff ={
    Name:'',
    Password:'',
    ConfirmPassword:'',
    Email:'',
    Phone:'',
    Address:'',
    BirthDate:new Date(),
    Department:'',
    Salary:new Number(),
    Highest_Qualification:'',
    Designation:''
  };

  selectedPatient:Patient={
    Name:'',
  Password:'',
  ConfirmPassword:'',
  Phone:'',
  Email:'',
  Address:'',
  BirthDate:new Date(),
  Gender:'',
  }

  selectedAppointment:Appointment={
    DoctorId: 0,
    PatientId: 0,
    DOA:new Date()
  };


  constructor(private http:HttpClient) { }
  postDoctor(doctor:Doctor)
  {
    return this.http.post(environment.apiUrl+'/Doctors/PostDoctor',doctor);
  }

  postPatient(patient:Patient)
  {
    return this.http.post(environment.apiUrl+'/Patients/PostPatient',patient);
  }

  getDepartmentInformation(){
    return this.http.get(environment.apiUrl+'/Departments');
   }

   getDoctorCount(){
     return this.http.get(environment.apiUrl+'/Doctors/GetDoctorCount');
   }
   postStaff(staff:Staff){
    return this.http.post(environment.apiUrl+'/OtherStaffs/PostOtherStaff',staff);
   }
   getAppointment(){
    return this.http.get(environment.apiUrl+'/Appointments');
   }

   getPatientCount(){
     return this.http.get(environment.apiUrl+'/Patients/GetPatientCount');
   }

   getTotalIncome(){
    return this.http.get(environment.apiUrl+'/Appointments/GetTotalIncome');
   }

   getDoctor(){
    return this.http.get(environment.apiUrl+'/Doctors');
   }

   getPatient(){
    return this.http.get(environment.apiUrl+'/Patients');
  }

  getStaff(){
    return this.http.get(environment.apiUrl+'/OtherStaffs');
  }
  getDoctorById(id:number){
    return this.http.get(environment.apiUrl+'/Doctors/GetdoctorById/'+id); 
  }
  getPatientById(id:number){
    return this.http.get(environment.apiUrl+'/Patients/GetPatientById/'+id); 
  }
  getStaffById(id:number){
    return this.http.get(environment.apiUrl+'/OtherStaffs/GetStaffById/'+id); 
  }
  deleteDoctorById(id:number){
    return this.http.delete(environment.apiUrl+'/Doctors/DeletedoctorById/'+id); 
  }
  deletePatientById(id:number){
    return this.http.delete(environment.apiUrl+'/Patients/DeletePatientById/'+id); 
  }
  deleteStaffById(id:number){
    return this.http.delete(environment.apiUrl+'/OtherStaffs/DeleteStaffById/'+id); 
  }
  postBill(bill:Bill)
  {
    return this.http.post(environment.apiUrl+'/Bills/PostBill',bill);
  }

  postAppointment(appointment:Appointment){
    return this.http.post(environment.apiUrl+'/Appointment',appointment);
  }


  GetDoctor_ByDeptId(id:number){
    return this.http.get(environment.apiUrl+'/Doctors/GetDoctor_ByDeptId/'+id);
}


  getBillDetailsById(id:number){
    return this.http.get(environment.apiUrl+'/Bills/GetBillDetails_usingPatientID/'+id);
  }
 
  deleteAppointmentById(id:number){
    return this.http.delete(environment.apiUrl+'/Appointments/deleteAppointmentById/'+id);
  }
  putAcceptedAppointment(id:number){
    return this.http.put(environment.apiUrl+'/Appointments/putAcceptedAppointment/'+id,{Headers});
  }
  getUnAcceptedAppointmentst(){
    return this.http.get(environment.apiUrl+'/Appointments/GetUnAcceptedAppointments');
   }
   getAcceptedAppointmentst(){
    return this.http.get(environment.apiUrl+'/Appointments/GetAcceptedAppointments');
   }

  userAuthentication(userName: string , password: string) {
    var data = "username=" + userName + "&password=" + password + "&grant_type=password";
    var reqHeader = new HttpHeaders({ 'Content-Type': 'application/x-www-urlencoded','No-Auth':'True' });
    return this.http.post('http://localhost:58490/token', data, { headers: reqHeader });
  }

  getAppointmentById(id:number){
    return this.http.get(environment.apiUrl+'/Appointments/GetAppointmentById/'+id);
  }

  getNotificationById(id:number){
    return this.http.get(environment.apiUrl+'/Appointments/GetPatientNotificationById/'+id);
  }

   
  roleMatch(allowedRoles: string[]): boolean {
 
    var isMatch = false;
    var userRoles: string = localStorage.getItem('userRoles')?.split(",")[0].split("\"")[1] || '{}';
       
    allowedRoles.forEach(element => {
      if (userRoles.indexOf(element) > -1) {
        isMatch = true;
        return false;
      }
      return ;
    });
    return isMatch;

  }

  login():number{
    this.loginid = parseInt( localStorage.getItem('userRoles')?.split(",")[1] || '{}');
    return this.loginid;
  }
  

}
  
