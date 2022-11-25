﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordleSolver.Data
{
    internal class DialogService : IDialogService
    {
         public async Task<bool> DisplayConfirm(string title, string message, string accept, string cancel)
        {
            return await Application.Current.MainPage.DisplayAlert(title, message, accept, cancel);
        }
         public async Task<string> DisplayPromptAsync(string title, string message, string accept, string cancel,string placeholder)
        {
            return await Application.Current.MainPage.DisplayPromptAsync(title, message,accept,cancel,placeholder);
        }
    }
}