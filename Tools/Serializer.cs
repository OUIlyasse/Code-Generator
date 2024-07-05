using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools
{
    public static class Serializer<T>
    {
        public static string SerializeToJSON(T type)
        {
            string rs = "";

            var settings = new JsonSerializerSettings
            {
                Formatting = Newtonsoft.Json.Formatting.Indented
            };

            rs = JsonConvert.SerializeObject(type, settings);
            return rs;
        }

        public static T DeserializeToJSON(string content)
        {
            T obj = (T)JsonConvert.DeserializeObject<T>(content);
            return obj;
        }
    }
}