import { Component, OnInit } from '@angular/core';
import { ManageclinicComponent } from '../manageclinic/manageclinic.component';
import { AdminhomeComponent } from '../adminhome/adminhome.component';
import { AdddoctorComponent } from '../adddoctor/adddoctor.component';
import { AddstaffComponent } from '../addstaff/addstaff.component';
import { ServiceService } from '../service.service';
@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {
  storedTheme: string = JSON.parse(localStorage.getItem('currentUser')!);
  constructor(public api : ServiceService) { }

  ngOnInit(): void {
  }
  setTheme() {
    if(this.storedTheme === 'theme-dark') {
      //toggle and update local storage
      localStorage.setItem('theme-color', 'theme-light');
      this.storedTheme = JSON.parse(JSON.stringify(localStorage.getItem('theme-color')!));
    } else {
      //toggle and update local storage
      localStorage.setItem('theme-color', 'theme-dark');
      this.storedTheme = JSON.parse(JSON.stringify(localStorage.getItem('theme-color')!));
    }
  }

}
