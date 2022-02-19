import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ResourcesDetailService } from '../Services/bookservice.model';
import { ToastrService } from 'ngx-toastr';
import { MatDialogRef,MAT_DIALOG_DATA } from '@angular/material/dialog';

@Component({
  selector: 'app-dialog',
  templateUrl: './dialog.component.html',
  styleUrls: ['./dialog.component.css']
})
export class DialogComponent implements OnInit {
bookingCommand !:FormGroup;
  constructor(private formBuilder:FormBuilder,public service:ResourcesDetailService,private toastr : ToastrService,
    @Inject(MAT_DIALOG_DATA)public data:any) { }

  ngOnInit(): void {
    this.bookingCommand=this.formBuilder.group({
      dateFrom:['',Validators.required],
      dateTo:['',Validators.required],
      BookedQuantity:['',Validators.required]
    })
  }
  bookResource(FormGroup:any){
    console.log(this.bookingCommand.value);
    this.service.FormGroup=FormGroup.value;
    this.service.FormGroup.ResourceId=this.data.resourceId;
this.service.postBookingDetails().subscribe(
  res=>{
    if(res!=null)
   {
    this.toastr.success('Successfully added', 'Booking is Done');
    console.warn("EMAIL SENT TO admin@admin.com FOR CREATED BOOKING WITH ID ",res)
   }
  else
  {
    this.toastr.info('Failed','this resource cannot be booked');
  }
  },
  err=>{console.log(err)}
);

  }
}
