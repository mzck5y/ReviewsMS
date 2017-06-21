using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;
using Reviews.Api.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reviews.Api.Data.DataContexts
{
    public class ReviewsDataContext
    {
        private readonly IMongoDatabase _db;

        public IMongoCollection<ReviewEntity> Reviews
        {
            get => _db.GetCollection<ReviewEntity>("reviews");
        }

        public ReviewsDataContext(string url)
        {
            MongoUrl murl = new MongoUrl(url);

            MongoClient client = new MongoClient(murl);
            _db = client.GetDatabase(murl.DatabaseName);

            ConventionPack pack = new ConventionPack();
            pack.Add(new CamelCaseElementNameConvention());
            ConventionRegistry.Register("Camel Case", pack, t => true);
        }
    }
}
