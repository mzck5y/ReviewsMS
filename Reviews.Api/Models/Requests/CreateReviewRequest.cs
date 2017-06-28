using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Reviews.Api.Models.Requests
{
    public class CreateReviewRequest
    {
        [Required]
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
    }
}
