using Mopups.Interfaces;

namespace DemoGame
{
    public partial class App : Application
    {
        IPopupNavigation popupNavigation;

        public App(IPopupNavigation popupNavigation)
        {
            InitializeComponent();
            this.popupNavigation = popupNavigation;
            MainPage = new MainPage(this.popupNavigation);
        }
    }
}