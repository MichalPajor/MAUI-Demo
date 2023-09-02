using Mopups.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoGame.Popups
{
    public static class PopupsManager
    {
        public static async Task<string> ShowSuccessPopupAndWaitForConfirmationAsync(IPopupNavigation popupNavigation)
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
        public static async Task<string> ShowFailPopupAndWaitForConfirmationAsync(IPopupNavigation popupNavigation)
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
    }  
}
