using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Reviews.Api.Data.Stores;
using Reviews.Api.Data.Entities;
using Reviews.Api.Models.Requests;
using System.Collections;
using Microsoft.AspNetCore.Authorization;

namespace Reviews.Api.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class ReviewsController : Controller
    {
        private readonly ReviewsStoreMongo _store;

        public ReviewsController(IReviewsStore store)
        {
            _store = (ReviewsStoreMongo)store;
        }

        [HttpPost]
        [Authorize(Policy = "ClientPolicy")]
        public IActionResult CreateReview( [FromBody] CreateReviewRequest request)
        {
            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }

            try
            {
                ReviewEntity entity = new ReviewEntity
                {
                    ProviderId = request.ProviderId,
                    ProviderFullName = request.ProviderFullName,
                    ProviderPictureUrl = request.ProviderPictureUrl,
                    ReviewerId = request.ReviewerId,
                    ReviewerFullName = request.ReviewerFullName,
                    ReviewerPictureUrl = request.ReviewerPictureUrl,
                    PostedDate = request.PostedDate,
                    Rating = request.Rating,
                    Title = request.Title,
                    Text = request.Text
                };

                _store.InsertReview(entity);

                return StatusCode(201);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("provider/{id}")]
        public IActionResult GetByProvider(string id)
        {
            try
            {
                IEnumerable<ReviewEntity> list = _store.GetAllByProviders(id);

                if (list.Count() <= 0)
                {
                    return NoContent();
                }

                return Ok(list);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("reviewer/{id}")]
        public IActionResult GetAllByReviewer(string id)
        {
            try
            {
                var list = _store.GetAllByReviewer(id);

                if (list.Count() <= 0)
                {
                    return NoContent();
                }

                return Ok(list);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
