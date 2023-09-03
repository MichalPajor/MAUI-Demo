using DemoGame.ViewModels;

namespace DemoGame.Views;

public partial class MediaPage : ContentPage
{
	public MediaPage(MediaViewModel vm)
	{
        Title = "Media mp3";
        InitializeComponent();
        BindingContext = vm;
    }
}