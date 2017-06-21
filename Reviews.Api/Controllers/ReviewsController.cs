using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Reviews.Api.Controllers
{
    [Route("api/[controller]")]
    public class ReviewsController : Controller
    {
        [HttpPost]
        public IActionResult CreateReview()
        {

        }
    }
}
