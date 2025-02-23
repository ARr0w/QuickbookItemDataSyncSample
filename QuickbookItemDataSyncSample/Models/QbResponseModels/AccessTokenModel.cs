using System.Text.Json.Serialization;

namespace QuickbookItemDataSyncSample.Models.QbResponseModels
{
    public class AccessTokenModel
    {
        [JsonPropertyName("refresh_token")]
        public string RefreshToken { get; set; } = null!;

        [JsonPropertyName("access_token")]
        public string AccessToken { get; set; } = null!;

        [JsonPropertyName("expires_in")]
        public int AccessTokenExpiry { get; set; }

        [JsonPropertyName("x_refresh_token_expires_in")]
        public int RefreshTokenExpiry { get; set; }
    }
}
