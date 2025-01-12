using ReviewApp.Database;
using ReviewApp.Interfaces;
using ReviewApp.Models;

namespace ReviewApp.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private DatabaseContext _databaseContext;
        public CategoryRepository(DatabaseContext context)
        {
            _databaseContext = context;
        }
        public DatabaseContext Context { get; }

        public bool CategoryExist(int id)
        {
            return _databaseContext.Categories.Any(c => c.Id == id);
        }

        public ICollection<Category> GetCategories()
        {
            return _databaseContext.Categories.ToList();
        }

        public Category GetCategory(int id)
        {
            return _databaseContext.Categories.Where(e => e.Id == id).FirstOrDefault();
        }

        public ICollection<Pokemon> GetPokemonByCategory(int categoryId)
        {
            return _databaseContext.PokemonCategories.Where(e => e.CategoryId == categoryId).Select(c => c.Pokemon).ToList();
        }
    }
}
