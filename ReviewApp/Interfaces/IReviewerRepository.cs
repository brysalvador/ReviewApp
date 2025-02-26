﻿using ReviewApp.Models;

namespace ReviewApp.Interfaces
{
    public interface IReviewerRepository
    {
        ICollection<Reviewer> GetReviewers();
        Reviewer GetReviewer(int reviewerId);
        ICollection<Review> GetReviewsByReviewer(int reviewerId);
        bool ReviewerExist(int reviewerId);

        bool CreateReviewer(Reviewer reviewer);

        bool UpdateReviewer(Reviewer reviewer);
        bool Save();
    }
}
