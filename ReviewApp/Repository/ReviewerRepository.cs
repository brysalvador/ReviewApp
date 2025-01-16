using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ReviewApp.Database;
using ReviewApp.Interfaces;
using ReviewApp.Models;

namespace ReviewApp.Repository
{
    public class ReviewerRepository : IReviewerRepository
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        public ReviewerRepository(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        Reviewer IReviewerRepository.GetReviewer(int reviewerId)
        {
            return _context.Reviewers.Where(r => r.Id == reviewerId).Include(e => e.Reviews).FirstOrDefault();
        }

        ICollection<Reviewer> IReviewerRepository.GetReviewers()
        {
            return _context.Reviewers.ToList();
        }

        ICollection<Review> IReviewerRepository.GetReviewsByReviewer(int reviewerId)
        {
            return _context.Reviews.Where(rw => rw.Reviewer.Id == reviewerId).ToList();
        }

        bool IReviewerRepository.ReviewerExist(int reviewerId)
        {
            return _context.Reviewers.Any(rw => rw.Id == reviewerId);
        }

        public bool CreateReviewer(Reviewer reviewer)
        {
            _context.Add(reviewer);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateReviewer(Reviewer reviewer)
        {
            _context.Update(reviewer);
            return Save();
        }
    }
}
