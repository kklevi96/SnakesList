using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakesList.ViewModels
{
    public partial class ViewModelBase : ObservableObject
    {
        [ObservableProperty]
        string title;
    }
}
