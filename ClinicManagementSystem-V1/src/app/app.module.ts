import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule,ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import{BrowserAnimationsModule} from '@angular/platform-browser/animations';
import {ToastrModule } from 'ngx-toastr';
import { DatePipe } from '@angular/common';
import {Ng2SearchPipeModule} from 'ng2-search-filter';
import { Ng2OrderModule } from 'ng2-order-pipe';
import { NgxPaginationModule } from 'ngx-pagination';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ManageclinicComponent } from './manageclinic/manageclinic.component';
import { AdminhomeComponent } from './adminhome/adminhome.component';
import { AdddoctorComponent } from './adddoctor/adddoctor.component';
import { AddstaffComponent } from './addstaff/addstaff.component';
import { RouterModule, Routes } from '@angular/router';
import { NavbarComponent } from './navbar/navbar.component';
import { GeneratebillComponent } from './generatebill/generatebill.component';
import { RegisterComponent } from './register/register.component';
import { InavbarComponent } from './inavbar/inavbar.component';
import { LoginComponent } from './login/login.component';
import { AuthGuard } from './auth/auth.guard';
import { ServiceService } from './service.service';
import { AuthInterceptor } from './auth/auth.interceptor';
import { NotificationsComponent } from './notifications/notifications.component';
import { PatientViewComponent } from './patient-view/patient-view.component';
import { CurrentAppointmentsComponent } from './current-appointments/current-appointments.component';
import { TakeAppointmentComponent } from './take-appointment/take-appointment.component';
import { BillsHistoryComponent } from './bills-history/bills-history.component';
import { TreatmentHistoryComponent } from './treatment-history/treatment-history.component';
import { FeedbackComponent } from './feedback/feedback.component';
import { DoctordetailsComponent } from './doctordetails/doctordetails.component';
import { TodaysappointmentComponent } from './todaysappointment/todaysappointment.component';
import { ViewappointmentsComponent } from './viewappointments/viewappointments.component';
import { PatienthistoryComponent } from './patienthistory/patienthistory.component';
import { PatientnavbarComponent } from './patientnavbar/patientnavbar.component';
import { DoctornavbarComponent } from './doctornavbar/doctornavbar.component';

const routes: Routes = [
  {path:'adminhome',component:AdminhomeComponent,canActivate: [AuthGuard] , data: { roles: ['1'] }},
  {path:'manageclinic',component:ManageclinicComponent,canActivate: [AuthGuard] , data: { roles: ['1'] }},
  {path:'adddoctor',component:AdddoctorComponent,canActivate: [AuthGuard] , data: { roles: ['1'] }},
  {path:'addstaff',component:AddstaffComponent,canActivate: [AuthGuard] , data: { roles: ['1'] }},
  {path:'navbar',component:NavbarComponent,canActivate: [AuthGuard] , data: { roles: ['1'] }},
  {path:'bill',component:GeneratebillComponent,canActivate: [AuthGuard] , data: { roles: ['1'] }},
  {path:'patient-view',component:PatientViewComponent,canActivate: [AuthGuard] , data: { roles: ['1','3'] }},
  {path:'notifications',component:NotificationsComponent,canActivate: [AuthGuard] , data: { roles: ['1','3'] }},
  {path:'current-appointments',component:CurrentAppointmentsComponent,canActivate: [AuthGuard] , data: { roles: ['1','3'] }},
  {path:'take-appointment',component:TakeAppointmentComponent,canActivate: [AuthGuard] , data: { roles: ['1','3'] }},
  {path:'bills-history',component:BillsHistoryComponent,canActivate: [AuthGuard] , data: { roles: ['1','3'] }},
  {path:'treatment-history',component:TreatmentHistoryComponent,canActivate: [AuthGuard] , data: { roles: ['1','3'] }},
  {path:'feedback',component:FeedbackComponent,canActivate: [AuthGuard] , data: { roles: ['1','3'] }},
  {path:'doctordetails',component:DoctordetailsComponent,canActivate: [AuthGuard] , data: { roles: ['1','2'] }},
  {path:'todaysappointment',component:TodaysappointmentComponent,canActivate: [AuthGuard] , data: { roles: ['1','2'] }},
  {path:'generatebill',component:GeneratebillComponent,canActivate: [AuthGuard] , data: { roles: ['1','2'] }},
  {path:'viewappointments',component:ViewappointmentsComponent,canActivate: [AuthGuard] , data: { roles: ['1','2'] }},
  {path:'patienthistory',component:PatienthistoryComponent,canActivate: [AuthGuard] , data: { roles: ['1','3'] }},
  {path:'register',component:RegisterComponent},
  {path:'login',component:LoginComponent},
  {path:'',redirectTo:'login',pathMatch:'full'}
];
@NgModule({
  declarations: [
    AppComponent,
    ManageclinicComponent,
    AdminhomeComponent,
    AdddoctorComponent,
    AddstaffComponent,
    NavbarComponent,
    GeneratebillComponent,
    RegisterComponent,
    InavbarComponent,
    LoginComponent,
    PatientViewComponent,
    NotificationsComponent,
    CurrentAppointmentsComponent,
    TakeAppointmentComponent,
    BillsHistoryComponent,
    TreatmentHistoryComponent,
    FeedbackComponent,
    DoctordetailsComponent,
    TodaysappointmentComponent,
    GeneratebillComponent,
    ViewappointmentsComponent,
    PatienthistoryComponent,
    PatientnavbarComponent,
    DoctornavbarComponent
  ],
  imports: [
    FormsModule,
    HttpClientModule,
    BrowserModule,
    AppRoutingModule,
    RouterModule.forRoot(routes),
    ReactiveFormsModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot(),
    Ng2SearchPipeModule,
    Ng2OrderModule,
    NgxPaginationModule

    ],
  providers: [DatePipe, AuthGuard,ServiceService,{
    provide : HTTP_INTERCEPTORS,
    useClass : AuthInterceptor,
    multi : true
  }],
  bootstrap: [AppComponent]
})
export class AppModule { }
