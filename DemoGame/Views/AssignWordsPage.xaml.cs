using DemoGame.ViewModels;

namespace DemoGame.Views;

public partial class AssignWordsPage : ContentPage
{
	public AssignWordsPage(AssignWordsViewModel vm)
	{
		Title = "Dopasuj s³ówka";
		InitializeComponent();
		BindingContext = vm;
	}
}