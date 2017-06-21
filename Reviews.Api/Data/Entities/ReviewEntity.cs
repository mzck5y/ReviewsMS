using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reviews.Api.Data.Entities
{
    public class ReviewEntity
    {
        #region Properties

        [BsonId]
        public string Id { get; set; } = Guid.NewGuid().ToString("N");

        [BsonRequired]
        public string ProviderId { get; set; }

        public string ProviderPictureUrl { get; set; }

        public string ProviderFullName { get; set; }

        public string ReviewerId { get; set; }

        public string ReviewerFullName { get; set; }

        public string ReviewerPictureUrl { get; set; }

        public DateTime PostedDate { get; set; }

        public Single Rating { get; set; }

        public string Title { get; set; }

        public string Text { get; set; }

        public string ServiceNameReceived { get; set; }

        public string ServiceProvidedTo { get; set; }

        public DateTime ServiceDate { get; set; }

        public uint ThumbsCount { get; set; }

        public uint FlagCount { get; set; }

        public IEnumerable<ReviewItem> ReviewItems { get; set; }

        #endregion
    }
}
