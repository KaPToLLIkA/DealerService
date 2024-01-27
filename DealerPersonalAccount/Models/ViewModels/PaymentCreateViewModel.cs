using DealerPersonalAccount.Models.Entity;
using System.ComponentModel.DataAnnotations;

namespace DealerPersonalAccount.Models.ViewModels
{
    public sealed class PaymentCreateViewModel : IViewModel<Payment>
    {
        [Required]
        [Display(Name = "Price")]
        [DataType(DataType.Currency)]
        public double Price { get; set; }

        public Payment BuildPayment()
        {
            return new Payment { Price = Price };
        }
    }
}