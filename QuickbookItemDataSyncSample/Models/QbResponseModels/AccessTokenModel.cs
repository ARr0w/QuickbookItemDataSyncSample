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

//To retrieve Authorize Code
//https://appcenter.intuit.com/app/connect/oauth2?client_id=ABSXNSkdBiw6uqXa15GpRnJvZ8ERl5jzsLT4IV4PbpIWWxAQon&scope=com.intuit.quickbooks.accounting&redirect_uri=https://developer.intuit.com/v2/OAuth2Playground/RedirectUrl&response_type=code&state=PlaygroundAuth#/OpenIdAuthorize

//string clientId = "ABSXNSkdBiw6uqXa15GpRnJvZ8ERl5jzsLT4IV4PbpIWWxAQon";
//string redirectUri = "https://developer.intuit.com/v2/OAuth2Playground/RedirectUrl"; // Must match what's set in QuickBooks Developer Portal
//string scope = "com.intuit.quickbooks.accounting";
//string state = "PlaygroundAuth#/OpenIdAuthorize"; // Random string for security
//string authUrl = $"https://appcenter.intuit.com/connect/oauth2?client_id={clientId}&response_type=code&scope={scope}&redirect_uri={redirectUri}&state={state}";

//Console.WriteLine("Open this URL in your browser:");
//Console.WriteLine(authUrl);
//Console.ReadKey();
