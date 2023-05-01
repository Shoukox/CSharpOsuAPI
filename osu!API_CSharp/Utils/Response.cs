using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace osu_API_CSharp.Utils
{
    internal class Response
    {
        public HttpResponseMessage responseMessage;

        public async Task<T> ReadResponseAndConvertJSONTo<T>()
        {
            string content = await responseMessage!.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(content)!;
        }

        public Response(HttpResponseMessage responseMessage)
        {
            this.responseMessage = responseMessage;
        }

        ~Response() {
            responseMessage.Dispose();
        }
    }
}
