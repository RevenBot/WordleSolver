using WordleSolver.Services.DbServices;

namespace WordleSolver;

public partial class App : Application
{
	public static WordRepository WordRepo { get; private set; }
	public App(WordRepository repo)
	{
		InitializeComponent();

		MainPage = new MainPage();

		WordRepo= repo;
	}
}
