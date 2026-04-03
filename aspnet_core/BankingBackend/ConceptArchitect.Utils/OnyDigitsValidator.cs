using System.ComponentModel.DataAnnotations;

namespace ConceptArchitect.Utils.Validators;


public class OnlyDigitsAttribute : ValidationAttribute
{
    public bool AllowSeparators { get; set; } //default false
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if(value==null)
            return ValidationResult.Success; //not my job to check required.

        var _value = value.ToString();

        for(var i=0;i<_value.Length;i++)
        {
            if (!(Char.IsDigit(_value[i])))
            {
                if(AllowSeparators && (_value[i]=='-' || _value[i]==' '))   
                    continue;
                return new ValidationResult($"Invalid character: {_value[i]}");
            }
        }

        return ValidationResult.Success; //if there is not error
    }
}



