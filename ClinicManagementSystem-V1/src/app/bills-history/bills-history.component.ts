import { DatePipe } from '@angular/common';
import { ThisReceiver } from '@angular/compiler';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import {ServiceService} from '../service.service'; 

@Component({
  selector: 'app-bills-history',
  templateUrl: './bills-history.component.html',
  styleUrls: ['./bills-history.component.css']
})

export class BillsHistoryComponent implements OnInit {

  public Bill_Details :any;
  constructor(private api : ServiceService, public router:Router,public datePipe: DatePipe) { }

  
  ngOnInit (): void {
    this.api. getBillDetailsById(this.api.login()).subscribe((Bill_Details)=>{
      this.Bill_Details=Bill_Details;
   });
  }
}
