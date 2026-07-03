using InfoTrackScraper.Domain;

namespace InfoTrackScraper.Application
{
    public class SolicitorService : ISolicitorService
    {
        private const string SolicitorClientName = "SolicitorsHttpClientName";
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        private readonly ISolicitorScraperService _solicitorScraperService;

        public SolicitorService( IHttpClientFactory httpClientFactory, IConfiguration configuration, ISolicitorScraperService solicitorScraperService )
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
            _solicitorScraperService = solicitorScraperService;
        }

        public async Task<List<Solicitor>> GetSolicitorsAsync( string location )
        {
            string httpClientName = _configuration[ SolicitorClientName ]!;
            var content = CreateHttpContent( location );
            var client = _httpClientFactory.CreateClient( httpClientName );

            var response = await client.PostAsync( string.Empty, content );
            response.EnsureSuccessStatusCode();

            var htmlData = await response.Content.ReadAsStringAsync();
            var solicitors = _solicitorScraperService.GetSolicitors( htmlData );

            return solicitors;
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
