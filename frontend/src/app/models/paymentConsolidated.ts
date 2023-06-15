import { Payment } from "./payment";

export interface PaymentConsolidated {
  payments: Payment[];
  totalConsolidatePayment: number
}
