using ReviewApp.Database;
using ReviewApp.Interfaces;
using ReviewApp.Models;

namespace ReviewApp.Repository
{
    public class PokemonRepository : IPokemonRepository

    {
        private readonly DatabaseContext _context;
        public PokemonRepository(DatabaseContext context)
        {
            _context = context;
        }

        public Pokemon GetPokemon(int id)
        {
            return _context.Pokemon.Where(p => p.Id == id).FirstOrDefault();
        }

        public Pokemon GetPokemon(string name)
        {
            return _context.Pokemon.Where(p => p.Name == name).FirstOrDefault();
        }

        public decimal GetPokemonRating(int pokeId)
        {
            var review = _context.Reviews.Where(p => p.Pokemon.Id == pokeId);
            if (review.Count() <= 0)
                return 0;
            return ((decimal)review.Sum(r => r.Rating) / review.Count());
        }
        public bool PokemonExists(int pokeId)
        {
            return _context.Pokemon.Any(p => p.Id == pokeId);
        }

        public ICollection<Pokemon> GetPokemons()
        {
            return _context.Pokemon.OrderBy(p => p.Id).ToList();
        }

        public bool CreatePokemon(int ownerId, int categoryId, Pokemon pokemon)
        {
            var pokemonOwnerEntity = _context.Owners.Where(a => a.Id == ownerId).FirstOrDefault();
            var pokemoncCategoryEntity = _context.Categories.Where(a => a.Id == categoryId).FirstOrDefault();

            var pokemonOwner = new PokemonOwner()
            { 
                Owner = pokemonOwnerEntity,
                Pokemon = pokemon
            };
            _context.Add(pokemonOwner);

            var pokemonCategory = new PokemonCategory()
            {
                Category = pokemoncCategoryEntity,
                Pokemon = pokemon,
            };

            _context.Add(pokemonCategory);
            _context.Add(pokemon);
            return Save();
        }
        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdatePokemon(int ownerId, int categoryId, Pokemon pokemon)
        {

            //var ownerEntity = _context.Owners.Where(a => a.Id == ownerId).FirstOrDefault();
            //var categoryEntity = _context.Categories.Where(a => a.Id == categoryId).FirstOrDefault();
            //var pokemonOwner = new PokemonOwner()
            //{
            //    Owner = ownerEntity,
            //    OwnerId = ownerEntity.Id,
            //    Pokemon = pokemon,
            //};

            //_context.Update(pokemonOwner);
           
            //var pokemonCategory = new PokemonCategory()
            //{
                
            //    Category = categoryEntity,
            //    CategoryId = categoryEntity.Id,
            //    Pokemon = pokemon,

            //};
            //_context.Update(pokemonCategory);
            _context.Update(pokemon);

            return Save();
        }
    }
}
