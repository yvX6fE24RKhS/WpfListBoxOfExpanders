using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;

namespace WpfListBoxOfExpanders
{
   internal partial class ObservableData(DataModel data) : ObservableObject
   {
      [ObservableProperty]
      private DataModel _data = data;

      [ObservableProperty]
      private bool _isSelected = false;

      [ObservableProperty]
      private bool _isExpanded = false;
   }
}
