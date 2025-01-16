using System.Diagnostics.Metrics;
using ReviewApp.Database;
using ReviewApp.Interfaces;
using ReviewApp.Models;

namespace ReviewApp.Repository
{
    public class OwnerRepository : IOwnerRepository
    {
        private readonly DatabaseContext _context;

        public OwnerRepository(DatabaseContext databaseContext)
        {
            _context = databaseContext;
        }
        Owner IOwnerRepository.GetOwner(int ownerId)
        {
            return _context.Owners.Where(o => o.Id == ownerId).FirstOrDefault();
        }

        ICollection<Owner> IOwnerRepository.GetOwnerOfAPokemon(int pokeId)
        {
            return _context.PokemonOwner.Where(p => p.PokemonId == pokeId).Select(o => o.Owner).ToList();
        }

        ICollection<Owner> IOwnerRepository.GetOwners()
        {
            return _context.Owners.ToList();
        }

        ICollection<Pokemon> IOwnerRepository.GetPokemonByOwner(int ownerId)
        {
            return _context.PokemonOwner.Where(p => p.OwnerId == ownerId).Select(p => p.Pokemon).ToList(); 
        }

        bool IOwnerRepository.OwnerExist(int ownerId)
        {
            return _context.Owners.Any(o => o.Id == ownerId);
        }
        public bool CreateOwner(Owner owner)
        {
            _context.Add(owner);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateOwner(Owner owner)
        {
            _context.Update(owner);
            return Save();
        }
    }
}
