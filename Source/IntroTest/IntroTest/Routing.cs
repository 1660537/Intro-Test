namespace IntroTest
{
    public class Routing
    {
        #region DEFAULT
        /// <summary>
        /// 
        /// </summary>
        public static readonly string HOME_NAME = "default";

        /// <summary>
        /// 
        /// </summary>
        public static readonly string HOME_TEMPLATE = "{controller=Home}/{action=Index}/{id?}";
        #endregion

        #region LOGIN
        /// <summary>
        /// 
        /// </summary>
        public static readonly string LOGIN_NAME = "login";

        /// <summary>
        /// 
        /// </summary>
        public static readonly string LOGIN_TEMPLATE = "{controller=Login}/{action=Login}/{id?}";
        #endregion

        #region RATING
        /// <summary>
        /// 
        /// </summary>
        public static readonly string RATING_NAME = "/rating";

        /// <summary>
        /// 
        /// </summary>
        public static readonly string RATING_TEMPLATE = "{controller=Rating}/{action=Rating}/{id?}";
        #endregion

        #region RATINGRESULT
        /// <summary>
        /// 
        /// </summary>
        public static readonly string RATINGRESULT_NAME = "/result";

        /// <summary>
        /// 
        /// </summary>
        public static readonly string RATINGRESULT_TEMPLATE = "{controller=Rating}/{action=Result}/{id?}";
        #endregion
    }
}
