import { Injectable } from '@angular/core';
import { HttpClient }  from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SharedService {
  readonly APIUrl = "http://localhost:44389/api"
  readonly photoURL = "http://localhost:44389/Images/";

  constructor(private http:HttpClient) {   }
 
  getAddressTypeList():Observable<any[]>{
    return this.http.get<any>(this.APIUrl + '/AddressType');
  }

  addAddressType(val:any){
    return this.http.post(this.APIUrl + '/AddressType', val)
  }

  updateAddressType(val:any){
    return this.http.put(this.APIUrl + '/AddressType', val)
  }

  deleteAddressType(val:any){
    return this.http.delete(this.APIUrl + '/AddressType', val)
  }

  //client services
  getClientList():Observable<any[]>{
    return this.http.get<any>(this.APIUrl + '/Client');
  }

  addClient(val:any){
    return this.http.post(this.APIUrl + '/Client', val)
  }

  updateClient(val:any){
    return this.http.put(this.APIUrl + '/Client', val)
  }

  deleteClient(val:any){
    return this.http.delete(this.APIUrl + '/Client', val)
  }

  //for uploading the image
  uploadImage(val:any){
    return this.http.get(this.APIUrl + '/Client/SaveFile', val)
  }

  getAllAdressTypeNames():Observable<any[]>{
    return this.http.get<any>(this.photoURL + '/Client/GetAllAddressTypeNames')
  }
}


