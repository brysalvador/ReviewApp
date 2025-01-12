using ReviewApp.Database;
using ReviewApp.Interfaces;
using ReviewApp.Models;

namespace ReviewApp.Repository
{
    public class PokemonRepository : IPokemonRepository

    {
        private readonly DatabaseContext _databaseContext;
        public PokemonRepository(DatabaseContext context)
        {
            _databaseContext = context;
        }

        public Pokemon GetPokemon(int id)
        {
            return _databaseContext.Pokemon.Where(p => p.Id == id).FirstOrDefault();
        }

        public Pokemon GetPokemon(string name)
        {
            return _databaseContext.Pokemon.Where(p => p.Name == name).FirstOrDefault();
        }

        public decimal GetPokemonRating(int pokeId)
        {
            var review = _databaseContext.Reviews.Where(p => p.Pokemon.Id == pokeId);
            if (review.Count() <= 0)
                return 0;
            return ((decimal)review.Sum(r => r.Rating) / review.Count());
        }
        public bool PokemonExists(int pokeId)
        {
            return _databaseContext.Pokemon.Any(p => p.Id == pokeId);
        }
        public Pokemon GetPokemon(Pokemon pokemon)
        {
            throw new NotImplementedException();
        }

        public ICollection<Pokemon> GetPokemons()
        {
            return _databaseContext.Pokemon.OrderBy(p => p.Id).ToList();
        }

    }
}
