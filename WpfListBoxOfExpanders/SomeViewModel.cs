using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;

namespace WpfListBoxOfExpanders
{
   internal partial class SomeViewModel : ObservableObject
   {
      [ObservableProperty]
      private ObservableCollection<ObservableData> _dataCollection = [];

      [ObservableProperty]
      private ObservableData? _selectedItem;

      public SomeViewModel()
      {
         DataCollection =
         [
            new( new DataModel
               {
                  ExpanderContentData = "ExpanderContentData_1",
                  ExpanderHeaderData = "ExpanderHeaderData_1"
               }) {
               IsExpanded = true,
               IsSelected = false
            },
            new( new DataModel
               {
                  ExpanderContentData = "ExpanderContentData_2",
                  ExpanderHeaderData = "ExpanderHeaderData_2"
               }) {
               IsExpanded = false,
               IsSelected = true
            },
            new( new DataModel
               {
                  ExpanderContentData = "ExpanderContentData_3",
                  ExpanderHeaderData = "ExpanderHeaderData_3"
               }) {
               IsExpanded = false,
               IsSelected = false
            }
         ];
      }
   }
}
