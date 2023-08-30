using Mopups.Pages;
using Mopups.Services;

namespace DemoGame.Popups;

public partial class FailPopup : PopupPage
{
    public event EventHandler<string> ResultConfirmed;
    public FailPopup()
	{
		InitializeComponent();
	}

    private async void PlayNext(object sender, EventArgs e)
    {
        ResultConfirmed?.Invoke(this, "Ok");
        await MopupService.Instance.PopAsync();
    }
    private async void PlayAgain(object sender, EventArgs e)
    {
        ResultConfirmed?.Invoke(this, "Retry");
        await MopupService.Instance.PopAsync();
    }
}