using AutoMapper;
using ReviewApp.Database;
using ReviewApp.Interfaces;
using ReviewApp.Models;

namespace ReviewApp.Repository
{
    public class CountryRepository : ICountryRepository
    {
        private readonly DatabaseContext _dataContext;
        private readonly IMapper _mapper;

        public CountryRepository(DatabaseContext datacontext, IMapper mapper)
        {
            _dataContext = datacontext;
            _mapper = mapper;
        }

        public bool CountryExist(int id)
        {
            return _dataContext.Countries.Any(c => c.Id == id);
        }

        public ICollection<Country> GetCountries()
        {
            return _dataContext.Countries.ToList();
        }

        public Country GetCountry(int countryId)
        {
            return _dataContext.Countries.Where(e => e.Id == countryId).FirstOrDefault();
        }

        public Country GetCountryByOwner(int ownerId)
        {
            return _dataContext.Owners.Where(o => o.Id == ownerId).Select(c => c.Country).FirstOrDefault();
        }

        public ICollection<Owner> GetOwnersFromACountry(int countryId)
        {
            return _dataContext.Owners.Where(c => c.Country.Id == countryId).ToList();
        }
    }
}
