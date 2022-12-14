namespace WordleSolver.Data.Wordle
{
	public interface IDialogService
	{
		Task<bool> DisplayConfirm(string title, string message, string accept, string cancel);
		Task<string> DisplayPromptAsync(string title, string message, string accept, string cancel, string placeholder);
	}
}
