using Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Domain.DTOs
{
    public class PaymentDTO
    {
        [Required(ErrorMessage = "Description is required")]
        public string Desciption { get; set; }

        [Required(ErrorMessage = "PaymentDate is required")]
        public DateTime PaymentDate { get; set; }

        [Required(ErrorMessage = "PaymentType is required")]
        public PaymentType PaymentType { get; set; }
        [Required(ErrorMessage = "PaymentAmount is required")]
        public decimal PaymentAmount { get; set; }
    }
}
