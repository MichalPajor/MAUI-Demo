using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DemoGame.Models;
using DemoGame.Popups;
using Microsoft.Maui.Controls;
using Mopups.Interfaces;

namespace DemoGame.ViewModels
{
    public partial class GuessWordViewModel : ObservableObject
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

        [ObservableProperty]
        string translatedWord;

        [ObservableProperty]
        string correctAnswer;

        [ObservableProperty]
        string resultWord;

        [ObservableProperty]
        ObservableCollection<ButtonCharHelper> charList;

        [RelayCommand]
        void Refresh()
        {
            RefreshRound();
        }
        [RelayCommand]
        void CheckResult()
        {
            CheckAnswer();
        }
        [RelayCommand]
        void CharButtonClicked(ButtonCharHelper btn)
        {
            Clicked(btn);
        }

        public GuessWordViewModel(IPopupNavigation popupNavigation)
        {
            this.popupNavigation = popupNavigation;
            LoadWords();
            randomizeChars(CorrectAnswer);
        }

        private async void CheckAnswer()
        {
            if (CorrectAnswer == ResultWord)
            {
                var result = await PopupsManager.ShowSuccessPopupAndWaitForConfirmationAsync(popupNavigation);
                if (result == "Ok")
                {
                    PlayNext();
                }
            }
            else
            {
                var result = await PopupsManager.ShowFailPopupAndWaitForConfirmationAsync(popupNavigation);
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

        public void Clicked(ButtonCharHelper item)
        {
            ResultWord += item.Value;
            CharList.Remove(item);
        }

        public void RefreshRound()
        {
            ResultWord = String.Empty;
            randomizeChars(CorrectAnswer);
        }
        
        private async Task randomizeChars(string input)
        {
            await Task.Delay(1000);
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
            CharList = new ObservableCollection<ButtonCharHelper>(result);
        }
    }
}