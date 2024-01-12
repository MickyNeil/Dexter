using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dexter
{
    public class Pokemon
    {
        public int PokedexNumber { get; set; }
        public string? Name { get; set; }
        public int Health { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int Speed { get; set; }
        public int Special {  get; set; }
        public int BaseStatTotal { get; set; }
        public List<PokemonMoves> pokemonMoves { get; set; } = new List<PokemonMoves>();

    }
}
