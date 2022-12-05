using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;

namespace WordleSolver.Data
{
	internal static class Utilities
	{
		public static async Task CreateToast(string text, ToastDuration duration = ToastDuration.Short, double fontSize = 14)
		{
			CancellationTokenSource cancellationTokenSource = new();

			var toast = Toast.Make(text, duration, fontSize);

			await toast.Show(cancellationTokenSource.Token);
		}
	}
}
