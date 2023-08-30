using DemoGame.Popups;
using DemoGame.ViewModels;
using Microsoft.Maui.Layouts;
using Mopups.Interfaces;
using Mopups.Services;
using System.Linq;

namespace DemoGame
{
    public partial class MainPage : ContentPage
    {
        private MainPageViewModel _viewModel;
       // //private List<char> clickedChars = new List<char>();
       //// List<char> charList = new List<char>();
        public MainPage(IPopupNavigation popupNavigation)
        {
            InitializeComponent();
            _viewModel = new MainPageViewModel(popupNavigation);
            BindingContext = _viewModel;
            
            //_viewModel.LoadWords();

            //CreateUI();        
        }
        //private void CreateUI()
        //{
        //    charList = randomizeChars(_viewModel.CorrectAnswer);

        //    foreach (char c in charList)
        //    {
        //        Button charButton = new Button
        //        {
        //            Text = c.ToString(),
        //            Margin = new Thickness(5),
        //            FontSize = 16,
        //            WidthRequest = 45,
        //            HeightRequest = 45,
        //            Style = (Style)Application.Current.Resources["CharButton"], // Przypisanie stylu
        //        };

        //        charButton.Clicked += (sender, e) =>
        //        {
        //            charButton.IsEnabled = false;
        //            clickedChars.Add(c); // Dodaj znak do listy wciśniętych znaków
        //            UpdateResultLabel(); // Aktualizuj etykietę
        //        };

        //        charFlexLayout.Children.Add(charButton);// Dodaj przycisk do układu
        //    }
        //}
        //private void UpdateResultLabel()
        //{
        //    resultLabel.Text = string.Join("", clickedChars); // Aktualizuj tekst etykiety
        //}
        //private async void CheckAnswer(object sender, EventArgs e)
        //{
        //    if(_viewModel.CorrectAnswer == resultLabel.Text)
        //    {
        //       var result = await ShowSuccessPopupAndWaitForConfirmationAsync();
        //        if(result == "Ok")
        //        {
        //            PlayNext();
        //        }
        //    }
        //    else
        //    {
        //        var result = await ShowFailPopupAndWaitForConfirmationAsync();
        //        if(result == "Retry")
        //        {
        //            RefreshRound();
        //        }
        //        else
        //        {
        //            PlayNext();
        //        }
        //    }
        //}

        //private void PlayNext()
        //{
        //    throw new NotImplementedException();
        //}

        //private async Task<string> ShowSuccessPopupAndWaitForConfirmationAsync()
        //{
        //    var tcs = new TaskCompletionSource<string>();

        //    var successPopup = new SuccessPopup();
        //    successPopup.ResultConfirmed += (sender, result) =>
        //    {
        //        tcs.TrySetResult(result); // Ustawienie rezultatu w TaskCompletionSource
        //    };

        //    await popupNavigation.PushAsync(successPopup);

        //    var finalResult = await tcs.Task; // Oczekiwanie na wynik

        //    return finalResult;
        //}
        //private async Task<string> ShowFailPopupAndWaitForConfirmationAsync()
        //{
        //    var tcs = new TaskCompletionSource<string>();

        //    var popup = new FailPopup();
        //    popup.ResultConfirmed += (sender, result) =>
        //    {
        //        tcs.TrySetResult(result); // Ustawienie rezultatu w TaskCompletionSource
        //    };

        //    await popupNavigation.PushAsync(popup);

        //    var finalResult = await tcs.Task; // Oczekiwanie na wynik

        //    return finalResult;
        //}
        //private void Refresh(object sender, EventArgs e)
        //{
        //    RefreshRound();
        //}

        //private void RefreshRound()
        //{

        //    resultLabel.Text = string.Empty;
        //    clickedChars.Clear();
        //    CreateUI();
        //    foreach (var child in charFlexLayout.Children)
        //    {
        //        if (child is Button charButton)
        //        {
        //            charButton.IsEnabled = true;
        //        }
        //    }
        //}

        //private List<char> randomizeChars(string input)
        //{
        //    List<char> charList = input.ToCharArray().ToList();
        //    // Mieszanie listy charów w losowej kolejności
        //    Random random = new Random();
        //    for (int i = charList.Count - 1; i > 0; i--)
        //    {
        //        int j = random.Next(i + 1);
        //        char temp = charList[i];
        //        charList[i] = charList[j];
        //        charList[j] = temp;
        //    }
        //    return charList;
        //}    
    }
    
}