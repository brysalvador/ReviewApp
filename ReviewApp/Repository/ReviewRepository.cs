using AutoMapper;
using ReviewApp.Database;
using ReviewApp.Interfaces;
using ReviewApp.Models;

namespace ReviewApp.Repository
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        public ReviewRepository(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        Review IReviewRepository.GetReview(int reviewId)
        {
            return _context.Reviews.Where(r => r.Id == reviewId).FirstOrDefault();
        }

        ICollection<Review> IReviewRepository.GetReviews()
        {
            return _context.Reviews.ToList();
        }

        ICollection<Review> IReviewRepository.GetReviewsOfAPokemon(int pokeId)
        {
            return _context.Reviews.Where(r => r.Id == pokeId).ToList(); 
        }

        bool IReviewRepository.ReviewExist(int reviewId)
        {
            return _context.Reviews.Any(r => r.Id == reviewId);
        }
        public bool CreateReview(Review review)
        {
             _context.Add(review);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateReview(int pokemonId, int reviewerId, Review review)
        {
            _context.Update(review);
            return Save();
        }
    }
}
