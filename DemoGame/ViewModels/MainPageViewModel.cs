using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using DemoGame.Models;
using DemoGame.Popups;
using Microsoft.Maui.Controls;
using Mopups.Interfaces;

namespace DemoGame.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged
    {

        List<Word> words = new List<Word>
        {
            new Word { Original = "Jabłko", Translated = "Apple" },
            new Word { Original = "Banan", Translated = "Banana" },
            new Word { Original = "Pomarańcza", Translated = "Orange" },
            new Word { Original = "Truskawka", Translated = "Strawberry" },
            new Word { Original = "Wiśnia", Translated = "Cherry" },
            new Word { Original = "Winogrono", Translated = "Grape" },
            new Word { Original = "Ananas", Translated = "Pineapple" },
            new Word { Original = "Mango", Translated = "Mango" },
            new Word { Original = "Gruszka", Translated = "Pear" },
            new Word { Original = "Malina", Translated = "Raspberry" },
            new Word { Original = "Brzoskwinia", Translated = "Peach" },
            new Word { Original = "Arbuz", Translated = "Watermelon" },
            new Word { Original = "Kiwi", Translated = "Kiwi" },
            new Word { Original = "Cytryna", Translated = "Lemon" },
            new Word { Original = "Pomelo", Translated = "Pomelo" },
            new Word { Original = "Granat", Translated = "Pomegranate" },
            new Word { Original = "Liczi", Translated = "Lychee" },
            new Word { Original = "Kaktus", Translated = "Cactus" },
            new Word { Original = "Papaja", Translated = "Papaya" },
            new Word { Original = "Melon", Translated = "Melon" },
            new Word { Original = "Rabarbar", Translated = "Rhubarb" },
            new Word { Original = "Śliwka", Translated = "Plum" },
            new Word { Original = "Jagoda", Translated = "Blueberry" },
            new Word { Original = "Agrest", Translated = "Currant" },
            new Word { Original = "Mandarynka", Translated = "Tangerine" }
        };

        IPopupNavigation popupNavigation;
        public ICommand CharButtonClickedCommand { get; set; }
        public ICommand RefreshCommand { get; set; }

        public ICommand CheckResultCommand { get; set; }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string name = "") =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));


        private string _translatedWord;
        public string TranslatedWord
        {
            get => _translatedWord;
            set
            {
                if (_translatedWord != value)
                {
                    _translatedWord = value;
                    OnPropertyChanged(); // reports this property
                }
            }
        }


        private string _correctAnswer;
        public string CorrectAnswer
        {
            get => _correctAnswer;
            set
            {
                if (_correctAnswer != value)
                {
                    _correctAnswer = value;
                    OnPropertyChanged(); // reports this property
                }
            }
        }

        private string _resultWord;
        public string ResultWord
        {
            get => _resultWord;
            set
            {
                if (_resultWord != value)
                {
                    _resultWord = value;
                    OnPropertyChanged(); // reports this property
                }
            }
        }

        private ObservableCollection<ButtonCharHelper> _charList;
        public ObservableCollection<ButtonCharHelper> CharList
        {
            get => _charList;
            set
            {
                if (_charList != value)
                {
                    _charList = value;
                    OnPropertyChanged(); // reports this property
                }
            }
        }
        private List<ButtonCharHelper> clickedChars = new List<ButtonCharHelper>();
        public MainPageViewModel(IPopupNavigation popupNavigation)
        {
            this.popupNavigation = popupNavigation;
            CharButtonClickedCommand = new Command<ButtonCharHelper>(CharButtonClicked);
            RefreshCommand = new Command(RefreshRound);
            CheckResultCommand = new Command(CheckAnswer);

            LoadWords();
            CharList = new ObservableCollection<ButtonCharHelper>(randomizeChars(CorrectAnswer));
        }

        private async void CheckAnswer()
        {
            if (CorrectAnswer == ResultWord)
            {
                var result = await ShowSuccessPopupAndWaitForConfirmationAsync();
                if (result == "Ok")
                {
                    PlayNext();
                }
            }
            else
            {
                var result = await ShowFailPopupAndWaitForConfirmationAsync();
                if (result == "Retry")
                {
                    RefreshRound();
                }
                else
                {
                    PlayNext();
                }
            }
        }

        private void PlayNext()
        {
            LoadWords();
            RefreshRound();
        }

        public void LoadWords()
        {
            Random random = new Random();
            int randomIndex = random.Next(0, words.Count);

            TranslatedWord = words[randomIndex].Original.ToUpper();
            CorrectAnswer = words[randomIndex].Translated.ToUpper();
        }

        public void CharButtonClicked(ButtonCharHelper item)
        {
            ResultWord += item.Value;
            CharList.Remove(item);
        }

        public void RefreshRound()
        {
            ResultWord = String.Empty;
            CharList = new ObservableCollection<ButtonCharHelper>(randomizeChars(CorrectAnswer));
        }

        private async Task<string> ShowSuccessPopupAndWaitForConfirmationAsync()
        {
            var tcs = new TaskCompletionSource<string>();

            var successPopup = new SuccessPopup();
            successPopup.ResultConfirmed += (sender, result) =>
            {
                tcs.TrySetResult(result); // Ustawienie rezultatu w TaskCompletionSource
            };

            await popupNavigation.PushAsync(successPopup);

            var finalResult = await tcs.Task; // Oczekiwanie na wynik

            return finalResult;
        }
        private async Task<string> ShowFailPopupAndWaitForConfirmationAsync()
        {
            var tcs = new TaskCompletionSource<string>();

            var popup = new FailPopup();
            popup.ResultConfirmed += (sender, result) =>
            {
                tcs.TrySetResult(result); // Ustawienie rezultatu w TaskCompletionSource
            };

            await popupNavigation.PushAsync(popup);

            var finalResult = await tcs.Task; // Oczekiwanie na wynik

            return finalResult;
        }

        private List<ButtonCharHelper> randomizeChars(string input)
        {
            List<char> charList = input.ToCharArray().ToList();
            // Mieszanie listy charów w losowej kolejności
            Random random = new Random();
            for (int i = charList.Count - 1; i > 0; i--)
            {
                int j = random.Next(i + 1);
                char temp = charList[i];
                charList[i] = charList[j];
                charList[j] = temp;
            }
            List<ButtonCharHelper> result = new List<ButtonCharHelper>();

            for (int i = 0; i < charList.Count; i++)
            {
                ButtonCharHelper btn = new ButtonCharHelper();
                btn.Value = charList[i];
                btn.Index = i;
                result.Add(btn);
            }          
            return result;
        }
    }
}