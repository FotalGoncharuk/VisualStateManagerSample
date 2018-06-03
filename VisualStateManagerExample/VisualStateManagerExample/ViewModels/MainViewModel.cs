using System.Windows.Input;
using VisualStateManagerExample.Validation;
using VisualStateManagerExample.Validation.Rules;
using Xamarin.Forms;

namespace VisualStateManagerExample.ViewModels
{
    public class MainViewModel : BaseViewModel
    {

        // ===== Public Fields =====

        public ValidatableObject<string> Password
        {
            get => Get<ValidatableObject<string>>();
            set => Set(value);
        }


        // ===== Commands =====

        public ICommand ValidatePasswordCommand 
            => new Command(ValidatePassword);

        private void ValidatePassword()
        {
            Password.Validate();        
        }


        // ===== Init =====

        public MainViewModel()
        {
            InitValidations();
        }

        private void InitValidations()
        {
            // Init Password 

            var rules = new IValidationRule<string>[]
            {
                new IsNotNullOrEmptyRule<string>("Password cannot be empty!", "Empty", 0),
                new PasswordLengthRule<string>("The minimum password is 5 characters", "Minimal", 
                    minimalPasswordLength: 5, priority: 1), 
                new PasswordLengthRule<string>("Weak Password", "Weak",
                    minimalPasswordLength: 8, priority: 2, canValid: true), 
                new PasswordLengthRule<string>("Medium Password", "Medium",
                    minimalPasswordLength: 12, priority: 3, canValid: true),
                new PasswordLengthRule<string>("Strong Password", "Strong",
                    minimalPasswordLength: 16, priority: 4, canValid: true),
            };
            Password = new ValidatableObject<string>(rules, defaultMessage: "Password");
        }
    }
}
