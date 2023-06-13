using EvilGenius.TimeTracker.Core.ViewModels;

namespace EvilGenius.TimeTracker.MacOS
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainViewModel();
        }
    }
}