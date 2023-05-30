using System;
using MudBlazor;
using System.Collections.Generic;
using System.Threading.Tasks;
using Grs.BioRestock.Client.Shared.Dialogs;
using Grs.BioRestock.Shared.Extensions;

namespace Grs.BioRestock.Client.Extensions
{
    public static class DialogServiceExtentions
    {
        public static async Task<DialogResult> ShowErrors(this IDialogService dialogService,
            List<string> responseMessages)
        {
            if (responseMessages.IsNullOrEmpty()) return null;
            var parameters = new DialogParameters();
            parameters.Add("Errors", responseMessages);
            var options = new DialogOptions { CloseButton = true, FullScreen = false, FullWidth = true };
            var dialog = await dialogService.ShowAsync<ErrorDialog>("Errors", parameters);
            var result = await dialog.Result;
            return result;
        }

        public static async Task<DialogResult> ShowErrors(this IDialogService dialogService,
            Exception ex)
        {
            if (ex == null) return null;
            var parameters = new DialogParameters();
            parameters.Add("Errors", new List<string>() { ex.Message });
            var options = new DialogOptions { CloseButton = true, FullScreen = false, FullWidth = true };
            var dialog = await dialogService.ShowAsync<ErrorDialog>("Errors", parameters, options);
            var result = await dialog.Result;
            return result;
        }
    }
}