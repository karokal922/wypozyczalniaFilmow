import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { PaymentResponse } from '../ModelResponses/payment-response';
import { UserAvgResponse } from '../ModelResponses/userAvg-response';
import { WeirdObject } from '../ModelResponses/weirdObject-response';

@Injectable({
  providedIn: 'root'
})
export class PaymentsService {
  private readonly url = "http://localhost:5096/api/PaymentApi";
  constructor(private httpClient : HttpClient) { }

  getUserAveragePaymentValue(id : number) : Observable<UserAvgResponse>{
    return this.httpClient.get<UserAvgResponse>(this.url+"/GetUserAveragePaymentValue?id="+id)
  }
  getPaymentsInRange(minPrice : number, maxPrice : number) : Observable<WeirdObject>{
    return this.httpClient.get<WeirdObject>(this.url+"/GetPaymentsInRange?minPrice="+minPrice+"&maxPrice="+maxPrice);
  }
  // get(): Observable<PaymentResponse[]> {
  //   return this.httpClient.get<PaymentResponse[]>(this.url2);
  // }

  // getOne(id:number): Observable<PaymentResponse> {
  //   return this.httpClient.get<PaymentResponse>(this.url2+'/'+id);
  // }

  // delete(id:number): Observable<boolean> {
  //   return this.httpClient.delete<boolean>(this.url2+'/'+id);
  // }

  // put(id:number, req:PaymentRequest): Observable<PaymentResponse> {
  //   return this.httpClient.put<PaymentResponse>(this.url2+'/'+id,req);
  // }

  // post(req: PaymentRequest): Observable<PaymentResponse> {
  //   return this.httpClient.post<PaymentResponse>(this.url2, req);
  // }

}
