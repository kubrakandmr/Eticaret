using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eticaret.MvcWEBUI.ExtensionMethods
{
    public static class SessionExtensionMethods
    {
        public static void SetObject(this ISession session, string key, object value)
        {
            string objectString = JsonConvert.SerializeObject(value); //value nun stringobje dğeri.
            session.SetString(key, objectString); 
        }

        public static T GetObject<T>(this ISession session, string key) where T : class
        { 
        string objectString = session.GetString(key);
        if(string.IsNullOrEmpty(objectString)) //sessionda böyle bir değer yoksa
        {
        return null; 
        }
        //değer varsa.
            T value = JsonConvert.DeserializeObject<T>(objectString);//objectstring T türünde bir nesne haline getir.Value aktar.
            return value;
        }
    }
}
