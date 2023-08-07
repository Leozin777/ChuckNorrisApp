using ChuckNorrisApp.Models;
using ChuckNorrisApp.Services.Interfaces;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace ChuckNorrisApp.ViewModel
{
    public class JokesChuckViewModel: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private readonly IServiceGeral _serviceGeral;

        private ICommand BuscaPiadaRandomCommand { get;set; }
        private ICommand BuscaPiadaEntryCommand { get;set; }

        private string _SearchEntry;
        public string c_SearchEntry
        {
            get => _SearchEntry; set
            {
                _SearchEntry = value;
                OnPropertyChanged();
            }
        }

        private SearchItem _SearchItemResult;
        public SearchItem c_SearchItemResult
        {
            get => _SearchItemResult; set
            {
                _SearchItemResult = value;
                OnPropertyChanged();
            }
        }

        private List<Joke> _SearchItemJokes;
        public List<Joke> c_SearchItemJokes
        {
            get => _SearchItemJokes; set
            {
                _SearchItemJokes = value;
                OnPropertyChanged();
            }
        }

        private Joke _Joke;
        public Joke c_Joke
        {
            get => _Joke; set
            {
                _Joke = value;
                OnPropertyChanged();
            }
        }

        private string _JokeString;
        public string c_JokeString
        {
            get => _JokeString; set
            {
                _JokeString = value;
                OnPropertyChanged();
            }
        }

        public JokesChuckViewModel(IServiceGeral p_serviceGeral)
        {
            _serviceGeral = p_serviceGeral;
            BuscaPiadaRandomCommand = new Command(async() => await BuscaPiadaRandom());
            BuscaPiadaEntryCommand = new Command(async() => await BuscaPiadaEntry());
        }

        private async Task BuscaPiadaEntry()
        {
            c_SearchItemResult = await _serviceGeral.GetJokeSearch(c_SearchEntry);
            foreach (var joke in c_SearchItemResult.result)
            {
                c_SearchItemJokes.Add(joke);
            }
        }

        public async Task BuscaPiadaRandom()
        {
            c_Joke = await _serviceGeral.GetRandomJoke();
            c_JokeString = c_Joke.value;
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
