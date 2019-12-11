using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace BC.Data.JsonManager
{
    public class JsonManager : IJsonManager
    {
        public List<T> ExtractTypesFromJson<T>(string directory)
        {
            var jsonToExtractFrom = File.ReadAllText(directory);
            var objects = JsonConvert.DeserializeObject<T[]>(jsonToExtractFrom);
            var result = new List<T>();
            foreach (var item in objects)
                result.Add(item);
            return result;
        }
    }
}
