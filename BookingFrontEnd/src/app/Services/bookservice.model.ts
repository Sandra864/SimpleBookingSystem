import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Resources } from './book.model';
import { BookingCommand } from './bookingResource.command';

@Injectable({
  providedIn: 'root'
})
export class ResourcesDetailService {
  constructor(private http:HttpClient) { 
  }

  readonly baseUrl ="https://localhost:44376/BookingApi";
  resourceList!: Resources[];
  FormGroup : BookingCommand = new BookingCommand();

  refreshList() {
    this.http.get(this.baseUrl)
      .toPromise()
      .then(res =>this.resourceList = res as Resources[]);
  }
  postBookingDetails(){
    return this.http.post(this.baseUrl,this.FormGroup);
  }

}

