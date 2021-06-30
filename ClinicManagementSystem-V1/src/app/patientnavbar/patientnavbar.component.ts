import { Component, OnInit } from '@angular/core';
import { ServiceService } from '../service.service';


@Component({
  selector: 'app-patientnavbar',
  templateUrl: './patientnavbar.component.html',
  styleUrls: ['./patientnavbar.component.css']
})
export class PatientnavbarComponent implements OnInit {
  
  title="Patient";
  storedTheme: string = JSON.parse(localStorage.getItem('currentUser')!);

  constructor(public api:ServiceService) { }

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
