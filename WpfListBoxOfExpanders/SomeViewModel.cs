using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;

namespace WpfListBoxOfExpanders
{
   internal partial class SomeViewModel : ObservableValidator
   {
      [ObservableProperty]
      private ObservableCollection<ObservableData> _dataCollection = [];

      [ObservableProperty]
      private ObservableData? _selectedItem;

      [ObservableProperty]
      private string? _someValue;

      public SomeViewModel()
      {
         DataCollection =
         [
            new( new DataModel
               {
                  //ExpanderHeaderData = "ValidExpanderHeaderData_1",
                  //ExpanderContentData = "ValidExpanderContentData_1"
                  ExpanderContentData = "ValidExpanderContentData_1",
                  ExpanderHeaderData = "ValidExpanderHeaderData_1"
               }) {
               IsExpanded = true,
               IsSelected = false
            },
            new( new DataModel
               {
                  ExpanderHeaderData = "ValidExpanderHeaderData_2",
                  ExpanderContentData = "InvalidExpanderContentData_2"
               }) {
               IsExpanded = true,
               IsSelected = true
            },
            new( new DataModel
               {
                  ExpanderHeaderData = "InvalidExpanderHeaderData_3",
                  ExpanderContentData = "ValidExpanderContentData_3"
               }) {
               IsExpanded = true,
               IsSelected = false
            },
            new( new DataModel
               {
                  ExpanderHeaderData = "InvalidExpanderHeaderData_4",
                  ExpanderContentData = "InvalidExpanderContentData_4"
               }) {
               IsExpanded = false,
               IsSelected = false
            }
         ];

         foreach (ObservableData item in DataCollection)
         {
            item.Data.ValidateAll();
         }
      }
   }
}
