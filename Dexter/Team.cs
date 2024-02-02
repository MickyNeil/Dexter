using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dexter
{
    class Team
    {
        public List<Pokemon> PokemonList { get; set; } = new List<Pokemon>();
        public string PokemonSlot { get; set; }
    }
}
