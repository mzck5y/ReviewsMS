using Reviews.Api.Data.DataContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Reviews.Api.Data.Entities;
using MongoDB.Driver;

namespace Reviews.Api.Data.Stores
{
    public class ReviewsStoreMongo : IReviewsStore
    {
        private readonly ReviewsDataContext _dc;

        public ReviewsStoreMongo(ReviewsDataContext ctx)
        {
            _dc = ctx;
        }

        public IEnumerable<ReviewEntity> GetAllByProviders(string providerId)
        {
            return _dc.Reviews.Find(r => r.ProviderId == providerId).ToList();
        }

        public IEnumerable<ReviewEntity> GetAllByReviewer(string revewerId)
        {
            var filter = Builders<ReviewEntity>.Filter.Eq(r => r.ReviewerId, revewerId);

            return _dc.Reviews.Find(filter).ToList();
        }

        public void InsertReview(ReviewEntity entity)
        {
            _dc.Reviews.InsertOne(entity);
        }
    }
}
