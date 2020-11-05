using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;

namespace ElectionVote.Services {
    public static class HttpRequest { 
        private static readonly HttpClient client = new HttpClient();


        public static async void Request() {
            HttpResponseMessage response;

            try {
                response = await client.GetAsync(
                    "https://sp321m383l.execute-api.eu-west-1.amazonaws.com/dev/health"
                    //new StringContent(
                    //    JsonConvert.SerializeObject(
                    //        new Dictionary<string, string> {
                    //        { "clientID", "88914c854e7f4c2687f971155584dabf" }
                    //        }
                    //    ),
                    //    Encoding.UTF8,
                    //    "text/json"
                    //)
                );

                response.EnsureSuccessStatusCode();
            } catch (Exception e) {
                Console.WriteLine("Exception");
                Console.WriteLine(e.Message);
                return;
            }

            string responseString = await response.Content.ReadAsStringAsync();
            var responseObject = JsonConvert.DeserializeObject<dynamic>(responseString);

            Console.WriteLine(responseString);
        }
    }
}
