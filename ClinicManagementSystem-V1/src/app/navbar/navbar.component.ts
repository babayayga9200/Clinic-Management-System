import { Component, OnInit } from '@angular/core';
import { ManageclinicComponent } from '../manageclinic/manageclinic.component';
import { AdminhomeComponent } from '../adminhome/adminhome.component';
import { AdddoctorComponent } from '../adddoctor/adddoctor.component';
import { AddstaffComponent } from '../addstaff/addstaff.component';
@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

}
