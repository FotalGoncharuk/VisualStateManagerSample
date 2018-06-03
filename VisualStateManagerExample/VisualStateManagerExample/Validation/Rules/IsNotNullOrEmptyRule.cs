namespace VisualStateManagerExample.Validation.Rules
{
    public class IsNotNullOrEmptyRule<T> : IValidationRule<T>
    {

        // ===== Public Fields =====

        public bool CanValid { get; set; }
        public string ValidationMessage { get; set; }
        public string State { get; set; }
        public int Priority { get; set; }


        // ===== Init =====

        public IsNotNullOrEmptyRule(
            string validationMessage, 
            string state, 
            int priority,
            bool canValid = false)
        {
            ValidationMessage = validationMessage;
            State = state;
            Priority = priority;
            CanValid = canValid;
        }


        // ===== Public Methods =====

        public bool Check(T value)
        {
            if (value == null)
            {
                return false;
            }

            var str = value as string;

            return !string.IsNullOrWhiteSpace(str);
        }
    }
}
