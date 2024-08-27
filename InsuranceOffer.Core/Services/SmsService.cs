using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace InsuranceOffer.Services
{
    public class SmsService : ISmsService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<SmsService> _logger;
        private readonly string _apiId = "b40eca67f177312d23281195";
        private readonly string _apiKey = "237839793d925d6d22bcb1a9";
        private readonly string _sender = "SMS TEST";
        private readonly string _messageType = "normal"; // normal veya turkce
        private readonly string _messageContentType = "bilgi"; // bilgi veya ticari
        private readonly string _postUrl = "https://api.vatansms.net/api/v1/NtoN";

        public SmsService(HttpClient httpClient, ILogger<SmsService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task SendSmsAsync(string phoneNumber, string verificationCode)
        {
            string message = $"Doğrulama kodunuz: {verificationCode}";

            var requestData = new
            {
                api_id = _apiId,
                api_key = _apiKey,
                sender = _sender,
                message_type = _messageType,
                message_content_type = _messageContentType,
                phones = new[]
                {
                    new { phone = phoneNumber, message }
                }
            };

            var jsonRequestData = JsonConvert.SerializeObject(requestData);
            var content = new StringContent(jsonRequestData, Encoding.UTF8, "application/json");

            try
            {
                var response = await _httpClient.PostAsync(_postUrl, content);
                var responseContent = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    _logger.LogInformation($"SMS sent successfully: {responseContent}");
                }
                else
                {
                    _logger.LogError($"Error sending SMS: {responseContent}");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error sending SMS: {ex.Message}");
            }
        }
    }
}
