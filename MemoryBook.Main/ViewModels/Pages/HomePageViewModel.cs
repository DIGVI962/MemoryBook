using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryBook.Main.ViewModels.Pages
{
    public partial class HomePageViewModel : ObservableObject
    {
        [ObservableProperty]
        private string title = "Home Page";

        public HomePageViewModel()
        {
        }
    }
}
