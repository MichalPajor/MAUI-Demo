using DemoGame.ViewModels;

namespace DemoGame.Views;

public partial class AssignWordsPage : ContentPage
{
	public AssignWordsPage(AssignWordsViewModel vm)
	{
		Title = "Dopasuj s��wka";
		InitializeComponent();
		BindingContext = vm;
	}
}