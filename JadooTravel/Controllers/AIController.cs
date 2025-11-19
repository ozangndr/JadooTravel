using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;

namespace JadooTravel.Controllers
{
    public class AIController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;

        

        public AIController(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _apiKey = configuration["OpenAI:ApiKey"];
        }

        [HttpGet]
        public async Task<IActionResult> GetPlaces(string location)
        {
            if (string.IsNullOrWhiteSpace(location))
                return Json(new { error = "Konum boş olamaz." });

            try
            {
                var prompt = $"{location} şehrinde veya ülkesinde gezilebilecek en popüler 10 yeri listele. " +
                             "Sadece yer isimlerini ver, numara koyma, satır satır yaz.";

                var requestBody = new
                {
                    model = "gpt-4o-mini",
                    messages = new[]
                    {
                        new { role = "user", content = prompt }
                    }
                };

                var content = new StringContent(JsonSerializer.Serialize(requestBody), Encoding.UTF8, "application/json");
                _httpClient.DefaultRequestHeaders.Clear();
                _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {_apiKey}");

                var response = await _httpClient.PostAsync("https://api.openai.com/v1/chat/completions", content);
                var responseText = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    return Json(new { error = $"OpenAI isteği başarısız: {response.StatusCode}", detail = responseText });
                }

                using var json = JsonDocument.Parse(responseText);

                // JSON içeriğini güvenli şekilde oku
                string? text = null;
                try
                {
                    text = json.RootElement
                        .GetProperty("choices")[0]
                        .GetProperty("message")
                        .GetProperty("content")
                        .GetString();
                }
                catch
                {
                    // fallback - bazen API farklı formatta döner
                    if (json.RootElement.TryGetProperty("choices", out var choices) &&
                        choices.GetArrayLength() > 0 &&
                        choices[0].TryGetProperty("text", out var altText))
                    {
                        text = altText.GetString();
                    }
                }

                if (string.IsNullOrWhiteSpace(text))
                    return Json(new { error = "API yanıtı boş döndü." });

                var places = text
                    .Split('\n', StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => x.Trim('-').TrimStart('•', ' ', '\t', '-', '–'))
                    .ToList();

                return Json(new { places });
            }
            catch (Exception ex)
            {
                return Json(new { error = "Bir hata oluştu.", detail = ex.Message });
            }
        }
    }
}
