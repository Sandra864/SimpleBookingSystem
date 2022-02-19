import { Component } from '@angular/core';
import { ResourcesDetailService } from './Services/bookservice.model';
import {MatDialog, MAT_DIALOG_DATA} from '@angular/material/dialog';
import { DialogComponent } from './dialog/dialog.component';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  constructor(public service:ResourcesDetailService,private dialog:MatDialog) { } 
  ngOnInit(): void {
    this.service.refreshList();
  }
  OnClickBook(resourceId:number){
    const dialogRef = this.dialog.open(DialogComponent,{
      width:'30%',
      data: {resourceId}
    });
  }
}
