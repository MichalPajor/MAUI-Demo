using DemoGame.Views;

namespace DemoGame
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(GuessWordPage), typeof(GuessWordPage));
        }
    }
}