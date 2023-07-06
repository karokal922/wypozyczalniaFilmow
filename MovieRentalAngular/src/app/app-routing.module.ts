import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PaymentsComponent } from './payments/payments.component';
import { PaymentsFormComponent } from './payments-form/payments-form.component';

const routes: Routes = [
  {
    path: 'payments', children: [
        { path: '', component: PaymentsComponent },
        { path: 'add', component: PaymentsFormComponent },
        { path: ':id/edit', component: PaymentsFormComponent }
    ]
},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
