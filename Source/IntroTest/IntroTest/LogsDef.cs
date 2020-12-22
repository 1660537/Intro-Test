namespace IntroTest
{
    using System;
    using System.Text;

    public class LogsDef
    {
        /// <summary>
        /// 
        /// </summary>
        private static string logMsg = "{0} {1} {2}";

        public static readonly string StartLogMsg = "Start";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj1"></param>
        /// <param name="obj2"></param>
        /// <param name="obj3"></param>
        /// <returns></returns>
        public static string GetLogInfo(Object obj1, Object obj2, Object obj3)
        {
            var sb = new StringBuilder();
            sb.AppendFormat(logMsg, obj1, obj2, obj3);
            return sb.ToString();
        }
    }
}
