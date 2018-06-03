using System.Collections.Generic;
using System.Linq;
using VisualStateManagerExample.Helpers;

namespace VisualStateManagerExample.Validation
{
    public class ValidatableObject<T> : Bindable, IValidation, IState
    {

        // ===== Public Fields =====

        public string State
        {
            get => Get<string>(null);
            private set => Set(value);
        }

        public string Message
        {
            get => Get<string>(null);
            private set => Set(value);
        }

        public T Value
        {
            get => Get<T>();
            set => Set(value);
        }

        public bool Valid
        {
            get => Get(false);
            private set => Set(value);
        }



        // ===== Private Fields =====

        private readonly List<IValidationRule<T>> _rules;


        // ===== Init =====

        public ValidatableObject(IEnumerable<IValidationRule<T>> rules, string defaultMessage)
        {
            _rules = new List<IValidationRule<T>>(
                rules.OrderBy(v => v.Priority)); // Sort by Priority

            Message = defaultMessage;
        }


        // ===== Public Methods =====

        public void Validate()
        {
            if (_rules.Count == 0)
            {
                return;
            }

            var firstInvalidRule = _rules.FirstOrDefault(v => !v.Check(Value)) 
                                   ?? GetLastRule();

            State = firstInvalidRule.State;
            Message = firstInvalidRule.ValidationMessage;
            Valid = firstInvalidRule.CanValid;
        }


        public void AddRule(IValidationRule<T> rule)
        {
            _rules.Add(rule);

            var insertIndex = GetInsertRuleIndex(rule.Priority);
            _rules.Insert(insertIndex, rule);
        }


        // ===== Private Methods =====

        private int GetInsertRuleIndex(int priority)
        {
            int index = 0;
            for (; index < _rules.Count; index++)
            {
                if (_rules[index].Priority > priority)
                    break;
            }

            return index;
        }
     

        private IValidationRule<T> GetLastRule()
        {
            return _rules[_rules.Count - 1];
        }
    }
}
