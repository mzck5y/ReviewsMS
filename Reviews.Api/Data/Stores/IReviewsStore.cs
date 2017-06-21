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
    }
}
