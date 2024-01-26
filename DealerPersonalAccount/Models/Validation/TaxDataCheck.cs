using System;
using System.ComponentModel.DataAnnotations;

namespace DealerPersonalAccount.Models.Validation
{
    public class TaxDataCheck : ValidationAttribute
    {
        private double _minExclusive;
        private double _maxInclusive;

        public TaxDataCheck(double minExclusive, double maxInclusive)
        {
            _minExclusive = minExclusive;
            _maxInclusive = maxInclusive;
        }

        public override bool IsValid(object value)
        {
            double tax = Convert.ToDouble(value);

            return tax > _minExclusive && tax <= _maxInclusive;
        }
    }
}