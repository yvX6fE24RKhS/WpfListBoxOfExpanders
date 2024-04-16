namespace WpfListBoxOfExpanders
{
   internal sealed class ValidationService : IValidationService
   {
      public bool IsExpanderContentDataValid(string value, string header)
         => value.StartsWith("Valid")
            && header.StartsWith("Valid");

      public bool IsExpanderHeaderDataValid(string value)
         => value.StartsWith("Valid");
   }
}
