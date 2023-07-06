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
  private readonly url2 = "http://localhost:5039/api/Payment";
  constructor(private httpClient : HttpClient) { }

  get(): Observable<PaymentResponse[]> {
    return this.httpClient.get<PaymentResponse[]>(this.url2);
  }

  getOne(id:number): Observable<PaymentResponse> {
    return this.httpClient.get<PaymentResponse>(this.url2+'/'+id);
  }

  delete(id:number): Observable<boolean> {
    return this.httpClient.delete<boolean>(this.url2+'/'+id);
  }

  put(id:number, req:PaymentRequest): Observable<PaymentResponse> {
    return this.httpClient.put<PaymentResponse>(this.url2+'/'+id,req);
  }

  post(req: PaymentRequest): Observable<PaymentResponse> {
    return this.httpClient.post<PaymentResponse>(this.url2, req);
  }
}
