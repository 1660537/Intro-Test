using IntroTest.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace IntroTest.Repositories
{
    public class RolesRepository
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly DataContext context;

        /// <summary>
        /// 
        /// </summary>
        public RolesRepository(DataContext dbContext)
        {
            this.context = dbContext;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns> </returns>
        public List<Roles> Read()
        {
            return this.context.Roles.AsNoTracking().OrderBy(r => r.Id).ThenBy(a => a.Name).ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns> </returns>
        public List<Roles> ReadById(Roles roles)
        {
            return this.context.Roles.AsNoTracking()
                                     .Where(r => r.Id.Equals(roles.Id))
                                     .OrderBy(r => r.Id).ThenBy(a => a.Name)
                                     .ToList();
        }
    }
}
