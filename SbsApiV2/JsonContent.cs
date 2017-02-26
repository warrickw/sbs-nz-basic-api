using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace SbsApiV2
{
    /// <summary>
    /// Json object http client content
    /// </summary>
    public class JsonContent : StringContent
    {
        public JsonContent(object model) : base(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json")
        {

        }
    }
}
