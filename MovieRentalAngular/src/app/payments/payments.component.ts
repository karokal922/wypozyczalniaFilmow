import { Component } from '@angular/core';
import { PaymentResponse } from '../ModelResponses/payment-response';
import { PaymentsService } from '../Services/payments.service';

@Component({
  selector: 'app-payments',
  templateUrl: './payments.component.html',
  styleUrls: ['./payments.component.css']
})
export class PaymentsComponent {
  payments : PaymentResponse[]=[];

  constructor(private paymentService : PaymentsService) {
    paymentService.get().subscribe({
      next:(res) => {
        this.payments = res;
      }
    })
  }

  onDeleteClick(payment: PaymentResponse): void {
    this.paymentService.delete(payment.id_Payment).subscribe({
      next: (res) => {
        this.paymentService.get().subscribe({
          next: (res2) => {
            this.payments = res2;
          }
        })
      }
    })
  }
}
