using ChuckNorrisApp.ViewModel;

namespace ChuckNorrisApp.View;

public partial class MainPage : ContentPage
{
	private JokesChuckViewModel _jokesChuckViewModel;
	public MainPage(JokesChuckViewModel p_jokesChuckViewModel)
	{
        _jokesChuckViewModel = p_jokesChuckViewModel;
        InitializeComponent();
		BindingContext = _jokesChuckViewModel;
	}

    protected async override void OnAppearing()
    {
        await _jokesChuckViewModel.BuscaPiadaRandom();
        base.OnAppearing();
    }
}

