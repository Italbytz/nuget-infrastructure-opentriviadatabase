using System.Text.Json.Serialization;

namespace Italbytz.Infrastructure.OpenTriviaDatabase
{
    public class TokenResponse
    {
        [JsonPropertyName("response_code")]
        public long ResponseCode { get; set; }

        [JsonPropertyName("response_message")]
        public string ResponseMessage { get; set; }

        [JsonPropertyName("token")]
        public string Token { get; set; }

    }
}

