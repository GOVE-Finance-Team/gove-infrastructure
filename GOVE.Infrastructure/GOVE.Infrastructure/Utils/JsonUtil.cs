using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOVE.Infrastructure.Utils;

public static class JsonUtil
{
    public static bool IsValidSchema(string json, string schema, out IList<string>? messages)
    {
        var jSchema = JSchema.Parse(schema);

        var data = JToken.Parse(json);

        return data.IsValid(jSchema, out messages);
    }
    public static string ToJson(this object obj)
    {
        return JsonConvert.SerializeObject(
        obj,
        Formatting.Indented,
        new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() }
        );
    }
}
