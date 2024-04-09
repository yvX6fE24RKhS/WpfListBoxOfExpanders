using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;

namespace WpfListBoxOfExpanders
{
   internal partial class DataModel : ObservableObject
   {
      [ObservableProperty]
      private string _expanderHeaderData = "";

      [ObservableProperty]
      private string _expanderContentData = "";
   }
}
