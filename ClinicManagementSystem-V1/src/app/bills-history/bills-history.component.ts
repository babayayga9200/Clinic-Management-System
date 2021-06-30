import { ThisReceiver } from '@angular/compiler';
import { Component, OnInit } from '@angular/core';
import {ServiceService} from '../service.service'; 

@Component({
  selector: 'app-bills-history',
  templateUrl: './bills-history.component.html',
  styleUrls: ['./bills-history.component.css']
})

export class BillsHistoryComponent implements OnInit {

  public Bill_Details :any;
  constructor(private api : ServiceService) { }

  
  ngOnInit (): void {
    this.api. getBillDetailsById(10).subscribe((Bill_Details)=>{
      this.Bill_Details=Bill_Details;
      console.log(Bill_Details); 
   });
  }
}
