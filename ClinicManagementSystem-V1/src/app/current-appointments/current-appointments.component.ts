import { Component, OnInit } from '@angular/core';
import { DatePipe } from '@angular/common';
import { ServiceService } from '../service.service';
import { Router, RouterModule, Routes } from '@angular/router';

@Component({
  selector: 'app-current-appointments',
  templateUrl: './current-appointments.component.html',
  styleUrls: ['./current-appointments.component.css']
})
export class CurrentAppointmentsComponent implements OnInit {
  appointment :any;

  constructor(private api:ServiceService,public datePipe: DatePipe) { }

  ngOnInit(): void {

    this.api.getAppointmentById(this.api.login()).subscribe((appointment: any)=>{
      this.appointment=appointment;
        });
  }

}
