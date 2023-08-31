using DemoGame.ViewModels;
using Mopups.Interfaces;

namespace DemoGame
{
    public partial class App : Application
    {
        IPopupNavigation popupNavigation;
        private MainPageViewModel mainVM;

        public App(IPopupNavigation popupNavigation, MainPageViewModel mainVM)
        {
            InitializeComponent();
            this.popupNavigation = popupNavigation;
            this.mainVM = mainVM;
            MainPage = new MainPage(this.mainVM);
        }
    }
}