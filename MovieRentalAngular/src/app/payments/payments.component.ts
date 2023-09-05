import { Component } from '@angular/core';
import { PaymentResponse } from '../ModelResponses/payment-response';
import { PaymentsService } from '../Services/payments.service';
import { UserAvgResponse } from '../ModelResponses/userAvg-response';
import { WeirdObject } from '../ModelResponses/weirdObject-response';


@Component({
  selector: 'app-payments',
  templateUrl: './payments.component.html',
  styleUrls: ['./payments.component.css']
})
export class PaymentsComponent {
  paymentsInRange : PaymentResponse[]=[];
  
  userAvgResult! : UserAvgResponse;
  minPrice : number = 0.0;
  maxPrice : number = 9999.0;
  userId : number = 0;
  showAvgTable : boolean = false;
  showPaymentTable : boolean = false;
  notNull : boolean = true;
  constructor(private paymentService : PaymentsService) {}
  
  getPaymentsInRange(){
    this.paymentService.getPaymentsInRange(this.minPrice, this.maxPrice).subscribe({
      next:(res) => {
        console.log(res);
        this.paymentsInRange = res["$values"];//this.weirdObj.values;
        console.log(this.paymentsInRange);
        this.showPaymentTable = true;
      }
    })
  }
  getUserAveragePaymentValue(){
    this.paymentService.getUserAveragePaymentValue(this.userId).subscribe({
      next:(res) => {
        this.userAvgResult = res;
        console.log(this.userAvgResult);
        if(this.userAvgResult==null){this.notNull=false;}
        else { this.notNull=true; } 
        this.showAvgTable = true;
      }
    })
  }
}
