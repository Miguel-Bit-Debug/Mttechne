import { Component } from '@angular/core';
import { PaymentConsolidated } from 'src/app/models/paymentConsolidated';
import { PaymentService } from 'src/app/services/payment.service';

@Component({
  selector: 'app-list-payments',
  templateUrl: './list-payments.component.html',
  styleUrls: ['./list-payments.component.scss']
})
export class ListPaymentsComponent {

  public payments!: PaymentConsolidated;
  public referenceDate!: Date;

  constructor(private paymentService: PaymentService) { }

  public getPaymentsByReferenceDate(referenceDate: Date) {
    this.paymentService.getPaymentsByReferenceDate(this.referenceDate).subscribe((res) => {
      this.payments = res;
    })
  }
}
