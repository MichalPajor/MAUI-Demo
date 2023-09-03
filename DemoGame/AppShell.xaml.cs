using DemoGame.Views;

namespace DemoGame
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(GuessWordPage), typeof(GuessWordPage));
            Routing.RegisterRoute(nameof(AssignWordsPage), typeof(AssignWordsPage));
            Routing.RegisterRoute(nameof(MediaPage), typeof(MediaPage));
        }
    }
}