namespace VisualStateManagerExample.Validation
{ 
    public interface IValidationRule<in T>
    {
        bool CanValid { get; set; }

        string ValidationMessage { get; set; }
        string State { get; set; }

        int Priority { get; set; }

        bool Check(T value);
    }
}
