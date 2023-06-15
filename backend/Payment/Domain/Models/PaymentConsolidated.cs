namespace Domain.Models
{
    public class PaymentConsolidated
    {
        public PaymentConsolidated(IEnumerable<Payment> payments,
                                   decimal totalConsolidatePayment)
        {
            Payments = payments;
            TotalConsolidatePayment = totalConsolidatePayment;
        }

        public IEnumerable<Payment> Payments { get; private set; }
        public decimal TotalConsolidatePayment { get; private set; }
    }
}
