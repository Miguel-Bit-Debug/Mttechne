import { Component } from '@angular/core';
import { Payment } from 'src/app/models/payment';
import { PaymentService } from 'src/app/services/payment.service';

@Component({
  selector: 'app-save-payments',
  templateUrl: './save-payments.component.html',
  styleUrls: ['./save-payments.component.scss']
})
export class SavePaymentsComponent {
  public description!: string;
  public paymentDate!: Date;
  public paymentType!: number;
  public paymentAmount!: number;

  constructor(private _paymentService: PaymentService) { }

  public doPayment() {
    let payment = new Payment(this.description,
                              this.paymentDate,
                              Number(this.paymentType),
                              this.paymentAmount);

    this._paymentService.doPayment(payment).subscribe((res) => { });
  }
}
