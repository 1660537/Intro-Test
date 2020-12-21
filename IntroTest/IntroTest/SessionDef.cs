using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace IntroTest
{
    public static class SessionDef
    {
        public static readonly string SESSION_USERLOGIN = "Session.UserLogin";

        public static string SESSION_USESTATE = "Session.UseState";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="session"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public static void SetObjectAsJson(this ISession session, string key, object value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="session"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static T GetObjectFromJson<T>(this ISession session, string key)
        {
            var value = session.GetString(key);

            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
        }
    }
}
