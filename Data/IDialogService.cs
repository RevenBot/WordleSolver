using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordleSolver.Data
{
    public interface IDialogService 
    {
        Task<bool> DisplayConfirm(string title, string message, string accept, string cancel);
        Task<string> DisplayPromptAsync(string title, string message, string accept, string cancel, string placeholder);
    }
}
