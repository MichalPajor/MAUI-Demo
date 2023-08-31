using DemoGame.ViewModels;

namespace DemoGame.Views;

public partial class MenuPage : ContentPage
{
	public MenuPage(MenuViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}