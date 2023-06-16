import { Component, OnInit } from '@angular/core';
import { Payment } from '../../../models/payment';
import { PaymentConsolidated } from 'src/app/models/paymentConsolidated';
import { PaymentService } from 'src/app/services/payment.service';

@Component({
  selector: 'app-list-payments',
  templateUrl: './list-payments.component.html',
  styleUrls: ['./list-payments.component.scss']
})
export class ListPaymentsComponent implements OnInit {

  public paymentConsolidated!: PaymentConsolidated;
  public payments!: Payment[];

  public referenceDate!: Date;
  displayedColumns: string[] = ['Description', 'PaymentDate', 'PaymentType', 'PaymentAmount'];

  ngOnInit(): void {
    this._paymentService.getAllPayments().subscribe((res) => {
      this.payments = res
    })
  }

  constructor(private _paymentService: PaymentService) { }


  public getPaymentsByReferenceDate() {
    this._paymentService.getPaymentsByReferenceDate(this.referenceDate).subscribe((res) => {
      this.paymentConsolidated = res;
    })
  }
}
