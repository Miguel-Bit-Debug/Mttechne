import { Component } from '@angular/core';
import { PaymentConsolidated } from 'src/app/models/paymentConsolidated';
import { PaymentService } from 'src/app/services/payment.service';

@Component({
  selector: 'app-list-payments',
  templateUrl: './list-payments.component.html',
  styleUrls: ['./list-payments.component.scss']
})
export class ListPaymentsComponent {

  public paymentConsolidated!: PaymentConsolidated;

  public referenceDate!: Date;
  displayedColumns: string[] = ['Description', 'PaymentDate', 'PaymentType', 'PaymentAmount'];


  constructor(private paymentService: PaymentService) { }

  public getPaymentsByReferenceDate() {
    this.paymentService.getPaymentsByReferenceDate(this.referenceDate).subscribe((res) => {
      this.paymentConsolidated = res;
    })
  }
}
