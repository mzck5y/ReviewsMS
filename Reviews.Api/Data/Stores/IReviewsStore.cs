using Reviews.Api.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reviews.Api.Data.Stores
{
    public interface IReviewsStore
    {
        void InsertReview(ReviewEntity entity);
        IEnumerable<ReviewEntity> GetAllByProviders(string providerId);
        IEnumerable<ReviewEntity> GetAllByReviewer(string revewerId);
    }
}
