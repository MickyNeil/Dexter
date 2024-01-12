using System.Collections.ObjectModel;
using System.Diagnostics;
using Google.Cloud.BigQuery.V2;

namespace Dexter
{
    public partial class MainPage : ContentPage
    {
        string projectId = "angelic-bee-400418";
        public ObservableCollection<Pokemon> PokemonList { get; set; } = new ObservableCollection<Pokemon>();
        public MainPage()
        {
            InitializeComponent();
            GetData();

            // Initialize PokemonList with Gen 1 Pokemon data
            //PokemonList = InitializeGen1PokemonList();

            // Set the binding context to the current page
            BindingContext = this;
            PokemonCollectionView.SelectionChanged += OnPokemonSelected;
        }
        private void GetData()
        {
            var client = BigQueryClient.Create(projectId);
            string query = $"SELECT * FROM `angelic-bee-400418.Pokemon.Gen1Pokemon` ORDER BY NO_ ASC";
            var listresult = client.ExecuteQuery(query, parameters: null);
            foreach (var row in listresult)
            {
                var pokedexNumber = row["No_"]?.ToString();
                var Name = row["Name"]?.ToString();
                var Health = MainPage.ParseToInt(row["HP"]?.ToString());
                var Attack = MainPage.ParseToInt(row["Attack"]?.ToString());
                var Defense = MainPage.ParseToInt(row["Defense"]?.ToString());
                var Speed = MainPage.ParseToInt(row["Speed"]?.ToString());
                var Special = MainPage.ParseToInt(row["Special"]?.ToString());
                var baseStatTotal = MainPage.ParseToInt(row["BST"]?.ToString());
                if (int.TryParse(pokedexNumber, out var pokedexNumberInt))
                {
                    PokemonList.Add(new Pokemon { PokedexNumber = pokedexNumberInt, Name = Name, Health = Health, Attack = Attack, Defense = Defense, Speed = Speed, Special = Special, BaseStatTotal = baseStatTotal});
                }
            }

        }
        private static int ParseToInt(string value)
        {
            int defaultvalue = 0;
            if (int.TryParse(value, out var intValue))
            {
                return intValue;
            }
            return defaultvalue; // or handle the case where parsing fails
        }
        private bool isSelectionHandled = false;

        private async void OnPokemonSelected(object sender, SelectionChangedEventArgs e)
        {
            if (!isSelectionHandled && e.CurrentSelection.FirstOrDefault() is Pokemon selectedPokemon)
            {
                isSelectionHandled = true; // Set a flag to indicate that selection is handled
                await Navigation.PushAsync(new PokemonDetailPage(selectedPokemon, PokemonCollectionView));
            }

            ((CollectionView)sender).SelectedItem = null;
            isSelectionHandled = false; // Reset the flag for the next selection
        }

    }
}
