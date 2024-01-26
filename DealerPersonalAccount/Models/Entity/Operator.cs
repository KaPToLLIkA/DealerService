using DealerPersonalAccount.Models.Validation;
using System.ComponentModel.DataAnnotations;

namespace DealerPersonalAccount.Models.Entity
{
    public sealed class Operator
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Name")]
        [StringLength(256, ErrorMessage = "Max 256 characters, min - 1", MinimumLength = 1)]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Tax")]
        [TaxDataCheck(0d, 1d, ErrorMessage = "Tax must be between 0 and 1")]
        [DisplayFormat(DataFormatString = "{0:n2}", ApplyFormatInEditMode = true)]
        public double Tax { get; set; }
    }
}