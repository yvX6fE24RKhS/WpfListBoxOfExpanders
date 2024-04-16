namespace WpfListBoxOfExpanders
{
   internal interface IValidationService
   {
      bool IsExpanderHeaderDataValid(string value);
      bool IsExpanderContentDataValid(string value, string header);
   }
}
