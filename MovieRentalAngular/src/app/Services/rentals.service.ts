import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class RentalsService {
  private readonly url = "";

  constructor(private httpClient : HttpClient) { }
}
