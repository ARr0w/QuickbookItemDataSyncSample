using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Configuration;
using QuickbookItemDataSyncSample.Models.QbResponseModels;

namespace QuickbookItemDataSyncSample.Services
{
    public class AuthService
    {
        private readonly IConfiguration _configuration;

        private readonly string _clientId = "CLIENT_ID_HERE";
        private readonly string _clientSecret = "CLIENT_SECRET_ID_HERE";
        private readonly string _credentials;
        private readonly string _authorizationCode;

        private AccessTokenModel? _accessTokenModel;

        public AuthService(IConfiguration configuration)
        {
            _configuration = configuration;
            _authorizationCode = configuration["code"]!;
            _credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{_clientId}:{_clientSecret}"));
        }

        public bool TokenAcquired { get; private set; } = false;

        public DateTime AccessTokenExpiry { get; private set; } = DateTime.UtcNow.AddMinutes(-10);

        public DateTime RefreshTokenExpiry { get; set; } = DateTime.UtcNow.AddMinutes(-10);

        public string AccessToken { get; set; }

        public async Task GetAccessToken()
        {
            try
            {
                if (_accessTokenModel == null)
                {
                    _accessTokenModel = await GetAccessTokenAsync();
                    return;
                }

                _accessTokenModel = await GetAccessTokenAsync("refreshToken");
            }
            catch (Exception ex)
            {
            }
        }

        private async Task<AccessTokenModel?> GetAccessTokenAsync(string grantType = "authorization_code")
        {
            TokenAcquired = false;

            string redirectUri = "https://developer.intuit.com/v2/OAuth2Playground/RedirectUrl";
            string tokenUrl = "https://oauth.platform.intuit.com/oauth2/v1/tokens/bearer";

            using (var client = new HttpClient())
            {

                client.DefaultRequestHeaders.Add("Authorization", $"Basic {_credentials}");

                Dictionary<string, string> requestData;

                if (grantType == "authorization_code")
                {
                    requestData = new Dictionary<string, string>
                    {
                        { "grant_type", "authorization_code" },
                        { "code", _authorizationCode },
                        { "redirect_uri", redirectUri }
                    };
                }
                else
                {
                    requestData = new Dictionary<string, string>
                    {
                        { "grant_type", "refresh_token" },
                        { "refresh_token", _accessTokenModel!.RefreshToken },
                    };
                }

                var requestBody = new FormUrlEncodedContent(requestData);
                var response = await client.PostAsync(tokenUrl, requestBody);
                var responseString = await response.Content.ReadAsStringAsync();

                Console.WriteLine(responseString);


                if (responseString.Contains("error"))
                {
                    return null;
                }

                TokenAcquired = true;
                var model = JsonSerializer.Deserialize<AccessTokenModel>(responseString)!;

                AccessTokenExpiry = DateTime.UtcNow.AddSeconds(model.AccessTokenExpiry);
                RefreshTokenExpiry = DateTime.UtcNow.AddSeconds(model.RefreshTokenExpiry);
                AccessToken = model.AccessToken;

                return model;
            }
        }
    }
}
