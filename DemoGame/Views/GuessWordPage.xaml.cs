using DemoGame.ViewModels;

namespace DemoGame.Views;

public partial class GuessWordPage : ContentPage
{
	public GuessWordPage(GuessWordViewModel vm)
	{
		Title = "Stw�rz s��wko";
		InitializeComponent();
        BindingContext = vm;
    }
}