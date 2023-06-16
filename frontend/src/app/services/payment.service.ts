import { Injectable } from "@angular/core";
import { HttpClient } from '@angular/common/http'
import { environment } from "../environment";
import { Observable } from "rxjs";
import { PaymentConsolidated } from "../models/paymentConsolidated";
import { Payment } from "../models/payment";

@Injectable({
  providedIn: 'root'
})
export class PaymentService {
  private readonly baseUrl: string = environment.baseUrl;
  constructor(private http: HttpClient) { }

  public getPaymentsByReferenceDate(referenceDate: any): Observable<PaymentConsolidated> {
    return this.http.get<PaymentConsolidated>(`${this.baseUrl}/api/Payment/payments-filter-date/${referenceDate}T00:00:00.000+00:00`);
  }

  public doPayment(payment: Payment): Observable<any> {
    return this.http.post(`${this.baseUrl}/api/Payment`, payment,
    { headers: {
      'Content-Type': 'application/json'}
    })
  }
}
