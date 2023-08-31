using DemoGame.ViewModels;

namespace DemoGame.Views;

public partial class GuessWordPage : ContentPage
{
	public GuessWordPage(GuessWordViewModel vm)
	{
		Title = "Stwórz s³ówko";
		InitializeComponent();
        BindingContext = vm;
    }
}