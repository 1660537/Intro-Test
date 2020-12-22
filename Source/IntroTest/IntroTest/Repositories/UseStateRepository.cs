using IntroTest.Models;

namespace IntroTest.Repositories
{
    public class UseStateRepository
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly DataContext context;

        /// <summary>
        /// 
        /// </summary>
        public UseStateRepository(DataContext dbContext)
        {
            this.context = dbContext;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="useState"></param>
        /// <returns></returns>
        public bool Add(UseState useState)
        {
            this.context.UseState.Add(useState);
            this.context.SaveChanges();
            return true;
        }
    }
}
