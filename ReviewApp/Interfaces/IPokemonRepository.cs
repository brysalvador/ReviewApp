using ReviewApp.Models;

namespace ReviewApp.Interfaces
{
    public interface IPokemonRepository
    {
        ICollection<Pokemon> GetPokemons();
        Pokemon GetPokemon(int id);
        Pokemon GetPokemon(string name);
        Pokemon GetPokemon(Pokemon pokemon);
        decimal GetPokemonRating(int pokeId);
        bool PokemonExists(int pokeId);
    }
}
