using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DemoGame.Models;
using DemoGame.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoGame.ViewModels
{
    public partial class MainPageViewModel : ObservableObject
    {
        [RelayCommand]
        async Task Navigation(MainMenuItem item)
        {
            switch (item.Id)
            {
                case 0:
                    {
                        await Shell.Current.GoToAsync(nameof(GuessWordPage));
                    }
                    break;
                default:
                    {
                        await Shell.Current.GoToAsync(nameof(AssignWordsPage));
                    }
                    break;
            }
            
        }

        [ObservableProperty]
        ObservableCollection<MainMenuItem> menuItems;

        public MainPageViewModel()
        {
            MenuItems = new ObservableCollection<MainMenuItem>()
            {
                new MainMenuItem(){Id=0, ItemTitle="Stwórz słówko", BgImageSource="guess_word.svg"},
                new MainMenuItem(){Id=1, ItemTitle="Dopasuj słówka", BgImageSource="guess_word.svg"},
                new MainMenuItem(){Id=2, ItemTitle="Item3", BgImageSource="guess_word.svg"},
                new MainMenuItem(){Id=3, ItemTitle="Item4", BgImageSource="guess_word.svg"},
                new MainMenuItem(){Id=4, ItemTitle="Item5", BgImageSource="guess_word.svg"},
                new MainMenuItem(){Id=5, ItemTitle="Item6", BgImageSource="guess_word.svg"},
                new MainMenuItem(){Id=5, ItemTitle="Item7", BgImageSource="guess_word.svg"},
                new MainMenuItem(){Id=5, ItemTitle="Item8", BgImageSource="guess_word.svg"},
                new MainMenuItem(){Id=5, ItemTitle="Item9", BgImageSource="guess_word.svg"},
                new MainMenuItem(){Id=5, ItemTitle="Item10", BgImageSource="guess_word.svg"},
                new MainMenuItem(){Id=5, ItemTitle="Item11", BgImageSource="guess_word.svg"},
                new MainMenuItem(){Id=5, ItemTitle="Item12", BgImageSource="guess_word.svg"},
            };

        }
    }
}
