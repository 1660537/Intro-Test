using IntroTest.Models;
using IntroTest.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;

namespace IntroTest.Controllers
{
    public class RatingController : BaseController
    {
        /// <summary>
        /// Data information
        /// </summary>
        private DataContext dbContext;

        /// <summary>
        /// 
        /// </summary>
        public RatingController(DataContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
            this.ratingRepository = new RatingRepository(dbContext);
        }

        public IActionResult Rating()
        {
            return View("/Views/Rating/Rating.cshtml");
        }

        [HttpPost]
        public IActionResult AddRating(Rating rating)
        {
            WriteLog(LogsDef.StartLogMsg);

            var useState = HttpContext.Session.GetObjectFromJson<UseState>(SessionDef.SESSION_USESTATE);
            if(useState != null)
            {
                rating.Date = DateTime.UtcNow;
                rating.IdRole = useState.IdRole;
                rating.Token = useState.Token;
            }
            ratingRepository.Add(rating);

            return Json("/rating/result");
        }

        public IActionResult Result()
        {
            return View("/Views/Rating/Result.cshtml");
        }
    }
}