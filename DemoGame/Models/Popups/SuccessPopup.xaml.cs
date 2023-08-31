using Mopups.Pages;
using Mopups.Services;

namespace DemoGame.Popups;

public partial class SuccessPopup : PopupPage
{
    public event EventHandler<string> ResultConfirmed;
    public SuccessPopup()
	{
		InitializeComponent();		
	}

    private async void PlayNext(object sender, EventArgs e)
    {
        ResultConfirmed?.Invoke(this, "Ok");
        await MopupService.Instance.PopAsync();
    }
}