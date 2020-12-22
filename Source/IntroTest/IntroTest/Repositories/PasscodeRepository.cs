using IntroTest.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace IntroTest.Repositories
{
    public class PasscodeRepository
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly DataContext context;

        /// <summary>
        /// 
        /// </summary>
        public PasscodeRepository(DataContext dbContext)
        {
            this.context = dbContext;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns> </returns>
        public Passcode ReadByIdAndCode(Passcode passcode)
        {
            return this.context.Passcode.AsNoTracking()
                                        .Where(p => p.IdRole.Equals(passcode.IdRole) && p.Code.Equals(passcode.Code))
                                        .OrderBy(p => p.IdRole).ThenBy(a => a.Code)
                                        .FirstOrDefault();
        }
    }
}
