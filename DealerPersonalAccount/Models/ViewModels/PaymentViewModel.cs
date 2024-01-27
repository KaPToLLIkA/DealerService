using DealerPersonalAccount.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DealerPersonalAccount.Models.ViewModels
{
    public class PaymentViewModel : IViewModel<Payment>
    {
        public int Id { get; set; }
        public DateTime CreationDateTime { get; set; }
        public DateTime? ClosingDateTime { get; set; }
        public string Operator { get; set; }
        public string Agent { get; set; }
        public double Price { get; set; }
    }
}