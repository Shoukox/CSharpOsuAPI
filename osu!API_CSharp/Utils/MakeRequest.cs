using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace osu_API_CSharp.Utils
{
    internal class MakeRequest
    {
        private HttpClient httpClient { get; set; }

        public static MakeRequest Create()
        {
            MakeRequest makeRequest = new MakeRequest();
            return makeRequest;
        }

        public async Task<Response> GetResponse(string urlWithParams)
        {
            using var requestMessage = new HttpRequestMessage(HttpMethod.Get, urlWithParams);
            var responseMessage = await httpClient.SendAsync(requestMessage);
            Response response = new Response(responseMessage);
            return response;
        }

        ~MakeRequest()
        {
            httpClient.Dispose();
        }

        private MakeRequest()
        {
            httpClient = new HttpClient();
        }
    }
}
