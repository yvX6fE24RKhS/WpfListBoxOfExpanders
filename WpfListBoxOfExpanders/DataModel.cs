using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Extensions.DependencyInjection;

namespace WpfListBoxOfExpanders
{
   public partial class DataModel : ObservableValidator
   {
      private static readonly IValidationService? validationService = App.Current.Services.GetService<IValidationService>();
      //private static readonly Dictionary<string, bool> emptyDictionary = [];
      private readonly Dictionary<string, bool> _validationStates = [];

      [ObservableProperty]
      [NotifyDataErrorInfo]
      [Required]
      [CustomValidation(typeof(DataModel), nameof(ValidateProperty))]
      private string _expanderHeaderData = "";

      [ObservableProperty]
      [NotifyDataErrorInfo]
      [Required]
      [CustomValidation(typeof(DataModel), nameof(ValidateProperty))]
      private string _expanderContentData = "";

      public DataModel()
      {
         this.ErrorsChanged += OnErrorsChanged;
      }

      private void OnErrorsChanged(object? sender, DataErrorsChangedEventArgs e)
      {
         if (!string.IsNullOrEmpty(e.PropertyName))
         {
            bool isValid = !GetErrors(e.PropertyName).Any();

            if (_validationStates.TryGetValue(e.PropertyName, out bool previousState))
            {
               _validationStates[e.PropertyName] = isValid;
            }
            else
            {
               _ = _validationStates.TryAdd(e.PropertyName, isValid);
            }

            if (isValid && !previousState) 
            {
               ValidateAllProperties();
            }
         }
      }

      public void ValidateAll() => ValidateAllProperties();

      public static ValidationResult ValidateProperty(string propertyValue, ValidationContext context)
      {
         bool isValid = true;
         DataModel instance = (DataModel)context.ObjectInstance;
         string? propertyName = context.MemberName;
         switch (propertyName)
         {
            case nameof(ExpanderHeaderData):
               isValid = validationService?.IsExpanderHeaderDataValid(propertyValue) ?? true;
               break;
            case nameof(ExpanderContentData):
               isValid = validationService?.IsExpanderContentDataValid(propertyValue, instance.ExpanderHeaderData) ?? true;
               break;
            default:
               break;
         }

         if (isValid)
         {
            return ValidationResult.Success!;
         }

         return new($"The Property {context.MemberName} was not validated by the validation service");
      }

   }
}
