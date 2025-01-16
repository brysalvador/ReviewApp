
using ReviewApp.Models;

namespace ReviewApp.Interfaces
{
    public interface IReviewRepository
    {
        ICollection<Review> GetReviews();
        Review GetReview(int reviewId);
        ICollection<Review> GetReviewsOfAPokemon(int pokeId);
        bool ReviewExist(int reviewId);

        bool CreateReview(Review review);

        bool UpdateReview(int pokemonId, int reviewerId, Review review);
        bool Save();
    }
}
