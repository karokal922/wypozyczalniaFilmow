import { Component } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { PaymentRequest } from 'src/app/ModelRequests/payment-request';
import { PaymentResponse } from 'src/app/ModelResponses/payment-response';
import { PaymentsService } from 'src/app/Services/payments.service';

@Component({
  selector: 'app-payments-form',
  templateUrl: './payments-form.component.html',
  styleUrls: ['./payments-form.component.css']
})
export class PaymentsFormComponent {
  form?: FormGroup = undefined;
  payment?: PaymentResponse = undefined;

  constructor(private formBuilder: FormBuilder, activatedRoute: ActivatedRoute, private paymentsService: PaymentsService, private router: Router) {
    activatedRoute.params.subscribe(params => {
      const id = params['id'];
      if (id > 0) {
        this.paymentsService.getOne(id).subscribe({
          next:
            (res) => {
              this.payment = res;
              this.createForm();
            }
        })
      }
      else {
        this.createForm();
      }
    });
  }

  private createForm() {
    this.form = this.formBuilder.group({
      price: this.formBuilder.control(this.payment?.price, [Validators.required, Validators.min(0)]),
    });
  }

  showError(name: string): boolean {
    if (!this.form) {
      return false;
    }
    const control = this.form.controls[name];
    return control.invalid && control.dirty;
  }

  onSubmit(): void {
    const req = new PaymentRequest(this.form?.value.price);

    if (this.payment) {
      this.paymentsService.put(this.payment.id_Payment, req).subscribe({
        next: x => {
          this.onCancelClick();
        }
      });
    } else {
      this.paymentsService.post(req).subscribe({
        next: x => {
          this.onCancelClick();
        }
      })
    }
  }

  onCancelClick(): void {
    this.router.navigateByUrl('payments');
  }
}
