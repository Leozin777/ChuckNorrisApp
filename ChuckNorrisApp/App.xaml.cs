using ChuckNorrisApp.View;

namespace ChuckNorrisApp;

public partial class App : Application
{
	public App(AppShell p_appShell)
	{
		InitializeComponent();
		Routing.RegisterRoute("MainPage", typeof(MainPage));
		Routing.RegisterRoute(nameof(JokesChuckView), typeof(JokesChuckView));
		Routing.RegisterRoute(nameof(AboutView), typeof(AboutView));

		MainPage = p_appShell;
    }
}
