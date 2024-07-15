using eshop.Web.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Newtonsoft.Json;

namespace eshop.Web.Extensions
{
    public static class SessionExtension
    {
        public static void SetJson(this ISession session,string sessionName,object value)
        {
            var serialized = JsonConvert.SerializeObject(value);
            session.SetString(sessionName, serialized);
        }

        public static T? GetJson<T>(this ISession session,string sessionName) where T : class 
        {
            var serialized=session.GetString(sessionName);
            return string.IsNullOrEmpty(serialized) ? null :
             JsonConvert.DeserializeObject<T>(serialized);
            

        } 
    }
}
