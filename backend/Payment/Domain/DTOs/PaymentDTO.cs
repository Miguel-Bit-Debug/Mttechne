using Domain.Enums;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Domain.DTOs
{
    public class PaymentDTO
    {
        [JsonProperty("description")]
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        [JsonProperty("paymentDate")]
        [Required(ErrorMessage = "PaymentDate is required")]
        public DateTime PaymentDate { get; set; }

        [JsonProperty("paymentType")]
        [Required(ErrorMessage = "PaymentType is required")]
        public PaymentType PaymentType { get; set; }

        [JsonProperty("paymentAmount")]
        [Required(ErrorMessage = "PaymentAmount is required")]
        public decimal PaymentAmount { get; set; }
    }
}
