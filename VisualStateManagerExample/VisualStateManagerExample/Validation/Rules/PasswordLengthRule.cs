using System;
using System.Collections.Generic;
using System.Text;

namespace VisualStateManagerExample.Validation.Rules
{
    public class PasswordLengthRule<T> : IValidationRule<T>
    {

        // ===== Public Fields =====

        public bool CanValid { get; set; }
        public string ValidationMessage { get; set; }
        public string State { get; set; }
        public int Priority { get; set; }

        public int MinimalPasswordLength { get; set; }


        // ===== Init =====

        public PasswordLengthRule(
            string validationMessage,
            string state,
            int minimalPasswordLength,
            int priority,
            bool canValid = false)
        {
            ValidationMessage = validationMessage;
            State = state;
            MinimalPasswordLength = minimalPasswordLength;
            Priority = priority;
            CanValid = canValid;
        }


        // ===== Public Methods =====

        public bool Check(T value)
        {
            var password = value as string;
            if (string.IsNullOrWhiteSpace(password))
            {
                return false;
            }

            return password.Length >= MinimalPasswordLength;
        }
    }
}
