using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Text.Json;

namespace LeetCodeApi.Controllers
{
    public class Model
    {
        public string url { get; set; }
        public string language { get; set; }
    }

    [Route("api/[controller]")]
    [ApiController]
    public class LeetCodeController : ControllerBase
    {
        private readonly string _openAiUrl = "https://api.openai.com/v1/completions";
        private readonly string _openAiKey = "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";
        private string _prompt; 

        [HttpPost] 
        public async Task<IActionResult> SolveLeetCode([FromBody] Model model)
        {
            if (ModelState.IsValid)
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Post, $"{_openAiUrl}");

                request.Headers.Add("Authorization", $"Bearer {_openAiKey}");
                _prompt = $"Given a {model.language} solution for the leetcode question below Leet Code Question: {model.url} {model.language} Solution:";

                //raw string format
                string s = $@"{{
                            ""model"": ""text-davinci-003"",    
                            ""prompt"": ""{_prompt}"",  
                            ""temperature"": 0,
                            ""max_tokens"": 2048,           
                            ""top_p"":1,                    
                            ""frequency_penalty"":0,        
                            ""presence_penalty"":0          
                          }}";

                //return type must be json format ("application/json")
                var content = new StringContent(s, null, "application/json");

                request.Content = content;
                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();

                //result is json string (read the response)
                var result = await response.Content.ReadAsStreamAsync();
                //json is json document (object)
                var json = JsonDocument.Parse(result);

                //cannot use this here as we need to pass back json format
                //var code = json.RootElement.GetProperty("choices")[0].GetProperty("text").ToString();
                
                return Ok(json);
            }
            else 
            {
                return BadRequest();
            };
        }
    }
}
