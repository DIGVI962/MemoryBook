using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MemoryBook.Main.Views.Pages;

namespace MemoryBook.Main.ViewModels
{
    public partial class MainPageViewModel : ObservableObject
    {
#region Fields
        [ObservableProperty]
        private Color hideLeftPaneButtonColor = Color.FromRgba(0, 0, 0, 0.4);

        [ObservableProperty]
        private Color showHomePageButtonColor = Color.FromRgba(255, 0, 0, 0.2);

        [ObservableProperty]
        private bool leftPaneVisible = true;

        [ObservableProperty]
        private int rightPaneColumn = 2;

        [ObservableProperty]
        private int rightPaneColumnSpan = 1;

        [ObservableProperty]
        private View? rightPaneContent;

        private HomePageView homePage;

        private bool showingHomePage = false; 
#endregion

        public MainPageViewModel()
        {
            homePage = new HomePageView();
        }

#region Commands
#region HideLeftPaneButton
        [RelayCommand]
        private void HideLeftPaneButton_PointEnterExit()
        {
            if (!LeftPaneVisible)
            {
                if (HideLeftPaneButtonColor.Equals(Color.FromRgba(0, 0, 0, 0.2)))
                {
                    HideLeftPaneButtonColor = Color.FromRgba(0, 0, 0, 0.4);
                }
                else if (HideLeftPaneButtonColor.Equals(Color.FromRgba(0, 0, 0, 0.4)))
                {
                    HideLeftPaneButtonColor = Color.FromRgba(0, 0, 0, 0.2);
                }
            }
        }

        [RelayCommand]
        private void HideLeftPaneButton_Click()
        {
            if (LeftPaneVisible == true)
            {
                LeftPaneVisible = false;
                RightPaneColumn = 0;
                RightPaneColumnSpan = 3;
                //HideButtonColor = Color.FromRgba(0, 0, 0, 0.2);
            }
            else
            {
                LeftPaneVisible = true;
                RightPaneColumn = 2;
                RightPaneColumnSpan = 1;
                HideLeftPaneButtonColor = Color.FromRgba(0, 0, 0, 0.4);
            }
        }
#endregion

#region ShowHomePageButton
        [RelayCommand]
        private void ShowHomePageButton_PointEnterExit()
        {
            if (!showingHomePage)
            {
                if (ShowHomePageButtonColor.Equals(Color.FromRgba(255, 0, 0, 0.2)))
                {
                    ShowHomePageButtonColor = Color.FromRgba(255, 0, 0, 0.4);
                }
                else if (ShowHomePageButtonColor.Equals(Color.FromRgba(255, 0, 0, 0.4)))
                {
                    ShowHomePageButtonColor = Color.FromRgba(255, 0, 0, 0.2);
                }
            }
        }

        [RelayCommand]
        private void ShowHomePageButton_Click()
        {
            if (!showingHomePage)
            {
                RightPaneContent = homePage.Content;
                showingHomePage = true;
                ShowHomePageButtonColor = Color.FromRgba(255, 0, 0, 0.4);
            }
            else
            {
                RightPaneContent = null;
                showingHomePage = false;
                //ShowHomePageButtonColor = Color.FromRgba(255, 0, 0, 0.2);
            }
        }
#endregion
#endregion
    }
}
