using System.Collections.Generic;

namespace BC.Data.JsonManager
{
    public interface IJsonManager
    {
        List<T> ExtractTypesFromJson<T>(string directory);
    }
}
