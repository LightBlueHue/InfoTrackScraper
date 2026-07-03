namespace InfoTrackScraper.Application
{
    public class SolicitorService : ISolicitorService
    {
        private const string SolicitorClientName = "SolicitorsHttpClientName";
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;

        public SolicitorService( IHttpClientFactory httpClientFactory, IConfiguration configuration )
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
        }

        public async Task<string> GetSolicitorsAsync( string location )
        {
            string httpClientName = _configuration[ SolicitorClientName ]!;
            var content = CreateHttpContent( location );
            var client = _httpClientFactory.CreateClient( httpClientName );
            var response = await client.PostAsync( string.Empty, content );
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        private FormUrlEncodedContent CreateHttpContent( string location )
        {
            var form = new Dictionary<string, string>
            {
                [ "did" ] = "Select area of law",
                [ "location" ] = location
            };

            return new FormUrlEncodedContent( form );
        }
    }
}
