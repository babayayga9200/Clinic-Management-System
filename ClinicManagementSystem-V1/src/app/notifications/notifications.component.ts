import { Component, OnInit } from '@angular/core';
import { ServiceService } from '../service.service';
@Component({
  selector: 'app-notifications',
  templateUrl: './notifications.component.html',
  styleUrls: ['./notifications.component.css']
})
export class NotificationsComponent implements OnInit {
  item:any;
  constructor(private api:ServiceService) { }

  ngOnInit(): void {
    this.api.getNotificationById(20).subscribe((notification: any)=>{
      this.item=notification;
      console.log(notification); 
        });
  }

}


