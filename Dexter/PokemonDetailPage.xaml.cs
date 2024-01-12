using Google.Cloud.BigQuery.V2;

namespace Dexter
{
    public partial class PokemonDetailPage : ContentPage
    {
        string projectId = "angelic-bee-400418";
        private CollectionView _pokemonCollectionView;

        public PokemonDetailPage(Pokemon selectedPokemon, CollectionView collectionView)
        {
            InitializeComponent();
            _pokemonCollectionView = collectionView;
            Title = selectedPokemon.Name;
            BindingContext = selectedPokemon;
            GetData(selectedPokemon);
            PokemonMoveList.SelectionChanged += OnMoveSelected;
        }

        private void GetData(Pokemon selectedPokemon)
        {
            var client = BigQueryClient.Create(projectId);
            string query = $"SELECT M.*, MS.Method FROM `angelic-bee-400418.Pokemon.Gen1Pokemon Moves` AS M JOIN `angelic-bee-400418.Pokemon.Gen1Pokemon Movesets` AS MS ON M.NO_ = MS.MID_ WHERE MS.PID_ = {selectedPokemon.PokedexNumber} ORDER BY MS.Method ASC";
            var listresult = client.ExecuteQuery(query, parameters: null);
            foreach (var row in listresult)
            {
                //var moveNumber = PokemonDetailPage.ParseToInt(row["NO_"]?.ToString());
                var moveName = row["Name"]?.ToString();
                var moveType = row["Type"]?.ToString();
                var movePowerPoints = PokemonDetailPage.ParseToInt(row["PP"]?.ToString());
                var movePower = row["Power"]?.ToString();
                var moveAccuracy = PokemonDetailPage.ParseToInt(row["Accuracy"]?.ToString());
                var moveEffect = row["Effect"]?.ToString();
                var learnMethod = row["Method"]?.ToString();
                selectedPokemon.pokemonMoves.Add(new PokemonMoves{ MoveName = moveName, MoveType = moveType, MovePowerPoints = movePowerPoints, MovePower = movePower, MoveAccuracy = moveAccuracy, MoveEffect = moveEffect, LearnMethod = learnMethod  });
            }
            Console.WriteLine("Moveset Populated");
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
        private async void OnMoveSelected(object sender, SelectionChangedEventArgs e)
        {
            if (!isSelectionHandled && e.CurrentSelection.FirstOrDefault() is PokemonMoves selectedMove)
            {
                isSelectionHandled = true; // Set a flag to indicate that selection is handled
                await Navigation.PushAsync(new MoveDetailPage(selectedMove, PokemonMoveList));
            }

            ((CollectionView)sender).SelectedItem = null;
            isSelectionHandled = false; // Reset the flag for the next selection
        }
    }
}
