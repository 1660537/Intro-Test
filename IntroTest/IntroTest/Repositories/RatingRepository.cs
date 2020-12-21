using IntroTest.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace IntroTest.Repositories
{
    public class RatingRepository
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly DataContext context;

        /// <summary>
        /// 
        /// </summary>
        public RatingRepository(DataContext dbContext)
        {
            this.context = dbContext;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns> </returns>
        public List<Rating> Read()
        {
            return this.context.Rating.AsNoTracking()
                                      .OrderBy(r => r.IdRole)
                                      .ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rating"></param>
        /// <returns></returns>
        public bool Add(Rating rating)
        {
            this.context.Rating.Add(rating);
            this.context.SaveChanges();
            return true;
        }
    }
}
