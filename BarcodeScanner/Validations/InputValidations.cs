using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace BarcodeScanner.Validations
{
    public class InputValidations : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            try
            {
                var price = Convert.ToDouble(value);

                if (price < 0)
                {
                    return new ValidationResult(false, "Price must be positive.");
                }
                return ValidationResult.ValidResult;
            }
            catch (Exception)
            {
                // Exception thrown by Conversion - value is not a number.
                return new ValidationResult(false, "Price must be a number.");
            }
        }
    }
    public class CellValidationRules : INotifyDataErrorInfo
    {
        public bool HasErrors {get;}
        public bool CanEdit => !HasErrors;

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        public IEnumerable GetErrors(string propertyName)
        {
            throw new NotImplementedException();
        }
    }
}
