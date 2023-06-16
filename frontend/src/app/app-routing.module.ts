import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ListPaymentsComponent } from './views/payment/list-payments/list-payments.component';
import { SavePaymentsComponent } from './views/payment/save-payments/save-payments.component';

const routes: Routes = [
  { path: '', component: ListPaymentsComponent },
  { path: 'new-transaction', component: SavePaymentsComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
