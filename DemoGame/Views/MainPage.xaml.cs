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
        public MainPage(MainPageViewModel vm)
        {
            InitializeComponent();
            BindingContext = vm;      
        }        
    }
    
}