import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ListPaymentsComponent } from './views/payment/list-payments/list-payments.component';

const routes: Routes = [
  { path: '', component: ListPaymentsComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
