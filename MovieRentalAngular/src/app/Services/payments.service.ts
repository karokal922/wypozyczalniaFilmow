import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { PaymentRequest } from '../ModelRequests/payment-request';
import { PaymentResponse } from '../ModelResponses/payment-response';

@Injectable({
  providedIn: 'root'
})
export class PaymentsService {
  private readonly url = "http://localhost:5236/api/Payments";

  constructor(private httpClient : HttpClient) { }

  get(): Observable<PaymentResponse[]> {
    let tmp=this.httpClient.get<PaymentResponse[]>(this.url);
    return tmp;
  }

  getOne(id:number): Observable<PaymentResponse> {
    return this.httpClient.get<PaymentResponse>(this.url+'/'+id);
  }

  delete(id:number): Observable<boolean> {
    return this.httpClient.delete<boolean>(this.url+'/'+id);
  }

  put(id:number, req:PaymentRequest): Observable<PaymentResponse> {
    return this.httpClient.put<PaymentResponse>(this.url+'/'+id,req);
  }
}
