using IntroTest.Repositories;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace IntroTest.Controllers
{
    public class BaseController : Controller
    {
        /// <summary>
        /// 
        /// </summary>
        protected RolesRepository rolesRepository;
        /// <summary>
        /// 
        /// </summary>
        protected PasscodeRepository passcodeRepository;
        /// <summary>
        /// 
        /// </summary>
        protected RatingRepository ratingRepository;
        /// <summary>
        /// 
        /// </summary>
        protected UseStateRepository useStateRepository;

        private string ControllerName { get { return ControllerContext.RouteData.Values["controller"].ToString(); } }

        /// <summary>
        /// 
        /// </summary>
        private string ActionName { get { return ControllerContext.RouteData.Values["action"].ToString(); } }

        public BaseController(DataContext dbContext)
        {
            rolesRepository = new RolesRepository(dbContext);
            passcodeRepository = new PasscodeRepository(dbContext);
        }

        protected void WriteLog(string LogInfo)
        {
            Log.Information(LogsDef.GetLogInfo(ControllerName, ActionName, LogInfo));
        }
    }
}