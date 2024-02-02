using System.Collections.ObjectModel;
using System.Linq;
using Microsoft.Maui.Controls;

namespace Dexter
{
    public partial class TeamBuilderPage : ContentPage
    {
        private ObservableCollection<Pokemon> AllPokemon { get; set; }
        private Team team;

        public TeamBuilderPage()
        {
            InitializeComponent();
            InitializePokemon();
            InitializeTeam();
        }

        private void InitializePokemon()
        {
            
            PokemonList.ItemsSource = AllPokemon;
        }

        private void InitializeTeam()
        {
            team = new Team();
            BindingContext = team;
        }

        private void OnPokemonSelected(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection.FirstOrDefault() is Pokemon selectedPokemon)
            {

            }
        }

        private void OnSlotClicked(object sender, System.EventArgs e)
        {

        }
    }
}
