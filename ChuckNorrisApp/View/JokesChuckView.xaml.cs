using ChuckNorrisApp.ViewModel;

namespace ChuckNorrisApp.View;

public partial class JokesChuckView : ContentPage
{
	private JokesChuckViewModel _JokesChuckViewModel;
	public JokesChuckView(JokesChuckViewModel p_JokesChuckViewModel)
	{
		InitializeComponent();
		BindingContext = _JokesChuckViewModel;
	}
}