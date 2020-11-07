using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ElectionVote.Services.DTO.Request;
using Newtonsoft.Json;

namespace ElectionVote.Services {
    public static class HttpRequest { 
        private static readonly HttpClient client = new HttpClient();

        public static async Task<String> Get(String url) {
            HttpResponseMessage response;

            response = await client.GetAsync(url);

            response.EnsureSuccessStatusCode();

            string responseString = await response.Content.ReadAsStringAsync();
            var responseObject = JsonConvert.DeserializeObject<dynamic>(responseString);

            return responseString;
        }

        public static async Task<String> Post(String url, IRequest requestDto) {
            HttpResponseMessage response;

            Console.WriteLine(JsonConvert.SerializeObject(requestDto));

            response = await client.PostAsync(
                url,
                new StringContent(
                    JsonConvert.SerializeObject(requestDto),
                    Encoding.UTF8,
                    "text/json"
                )
            );

            response.EnsureSuccessStatusCode();

            string responseString = await response.Content.ReadAsStringAsync();
            var responseObject = JsonConvert.DeserializeObject<dynamic>(responseString);

            return responseString;
        }
    }
}
