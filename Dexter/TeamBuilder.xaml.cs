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
            team.PokemonSlot1 = new PokemonSlot();
            team.PokemonSlot2 = new PokemonSlot();
            team.PokemonSlot3 = new PokemonSlot();
            team.PokemonSlot4 = new PokemonSlot();
            team.PokemonSlot5 = new PokemonSlot();
            team.PokemonSlot6 = new PokemonSlot();
            BindingContext = team;
        }

        private void OnPokemonSelected(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection.FirstOrDefault() is Pokemon selectedPokemon)
            {
                if (team.PokemonSlot1.Pokemon == null)
                {
                    team.PokemonSlot1.Pokemon = selectedPokemon;
                }
                else if (team.PokemonSlot2.Pokemon == null)
                {
                    team.PokemonSlot2.Pokemon = selectedPokemon;
                }
                else if (team.PokemonSlot3.Pokemon == null)
                {
                    team.PokemonSlot3.Pokemon = selectedPokemon;
                }
                else if (team.PokemonSlot4.Pokemon == null)
                {
                    team.PokemonSlot4.Pokemon = selectedPokemon;
                }
                else if (team.PokemonSlot5Pokemon == null)
                {
                    team.PokemonSlot5.Pokemon = selectedPokemon;
                }
                else if (team.PokemonSlot6.Pokemon == null)
                {
                    team.PokemonSlot6.Pokemon = selectedPokemon;
                }
                ((CollectionView)sender).SelectedItem = null;
            }
        }

        private void OnSlotClicked(object sender, System.EventArgs e)
        {

        }
    }
}
