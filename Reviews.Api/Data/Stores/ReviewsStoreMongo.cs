using Reviews.Api.Data.DataContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Reviews.Api.Data.Entities;

namespace Reviews.Api.Data.Stores
{
    public class ReviewsStoreMongo : IReviewsStore
    {
        private readonly ReviewsDataContext _dc;

        public ReviewsStoreMongo(ReviewsDataContext ctx)
        {
            _dc = ctx;
        }

        public void InsertReview(ReviewEntity entity)
        {
            _dc.Reviews.InsertOne(entity);
        }
    }
}
