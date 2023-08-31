using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DemoGame.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoGame.ViewModels
{
    public partial class MainPageViewModel : ObservableObject
    {
        [RelayCommand]
        async Task GoNext()
        {
            await Shell.Current.GoToAsync(nameof(GuessWordPage));
        }
        public MainPageViewModel()
        {
            
        }

    }
}
