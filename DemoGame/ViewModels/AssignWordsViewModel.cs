using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DemoGame.Models;
using DemoGame.Popups;
using DemoGame.Utils;
using Microsoft.Maui.Controls.Compatibility;
using Mopups.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoGame.ViewModels
{
    public partial class AssignWordsViewModel : ObservableObject
    {
        List<Word> words;
        IPopupNavigation popupNavigation;
        [ObservableProperty]
        ObservableCollection<AssignWordHelper> originalWords;

        [ObservableProperty]
        ObservableCollection<AssignWordHelper> assignedWords;

        [ObservableProperty]
        ObservableCollection<AssignWordHelper> toAssignWords;

        private AssignWordHelper draggedItem;

        [RelayCommand]
        void DragStart(AssignWordHelper item)
        {
            draggedItem = item;
        }
        [RelayCommand]
        void DragDrop(AssignWordHelper item)
        {
            ToAssignWords.Remove(draggedItem);
            AssignedWords.Remove(item);
            AssignedWords.Insert(item.Row,draggedItem);
        }
        [RelayCommand]
        void CheckResult()
        {
            CheckAnswer();
        }

        async Task Load()
        {
            await Task.Delay(600);
            LoadWords();
            words = RngUtils.ShuffleList(words);
            OriginalWords = new ObservableCollection<AssignWordHelper>();
            AssignedWords = new ObservableCollection<AssignWordHelper>();
            ToAssignWords = new ObservableCollection<AssignWordHelper>();
            int counter = 0;
            foreach(var item in words) { 
                AssignWordHelper originalItem = new AssignWordHelper() { Row = item.Id, Text = item.Original };
                AssignWordHelper assignedItem = new AssignWordHelper() { Row = counter};
                AssignWordHelper toAssignItem = new AssignWordHelper() { Row = item.Id, Text = item.Translated };
                OriginalWords.Add(originalItem);
                AssignedWords.Add(assignedItem);
                ToAssignWords.Add(toAssignItem);
                counter++;
            }
            ToAssignWords = new ObservableCollection<AssignWordHelper>(RngUtils.ShuffleList(ToAssignWords.ToList()));

        }
        private async void CheckAnswer()
        {
            bool isOk = true;
            for (int i = 0; i < OriginalWords.Count; i++)
            {
                if (OriginalWords[i].Row != AssignedWords[i].Row || String.IsNullOrEmpty(AssignedWords[i].Text))
                {
                    isOk = false;
                    break;
                }
            }
            if (isOk)
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
        public void RefreshRound()
        {
            Load();
        }
        private void PlayNext()
        {
            LoadWords();
            RefreshRound();
        }
        private void LoadWords()
        {
            Random rng = new Random();
            if(rng.Next(1, 3) %2 == 0)
            {
                words = new List<Word>
                {
                    new Word { Original = "Mango", Translated = "Mango", Id = 0  },
                    new Word { Original = "Gruszka", Translated = "Pear", Id = 1  },
                    new Word { Original = "Malina", Translated = "Raspberry", Id = 2 },
                    new Word { Original = "Brzoskwinia", Translated = "Peach", Id = 3 },
                    new Word { Original = "Arbuz", Translated = "Watermelon", Id = 4 },
                };
            }
            else
            {
                words = new List<Word> 
                {
                new Word { Original = "Jabłko", Translated = "Apple", Id = 0 },
                new Word { Original = "Banan", Translated = "Banana", Id = 1 },
                new Word { Original = "Pomarańcza", Translated = "Orange", Id = 2 },
                new Word { Original = "Truskawka", Translated = "Strawberry", Id = 3 },
                new Word { Original = "Wiśnia", Translated = "Cherry", Id = 4 },
                new Word { Original = "Winogrono", Translated = "Grape", Id = 5 },
                new Word { Original = "Ananas", Translated = "Pineapple", Id = 6 },
                new Word { Original = "Mango", Translated = "Mango", Id = 7 },
                };
            }
        }
        public AssignWordsViewModel(IPopupNavigation popupNavigation) 
        {
            this.popupNavigation = popupNavigation;
            Load();
        }
    }
}
