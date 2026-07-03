using System.Net;

namespace InfoTrackScraper.Infrastructure
{
    public static class ServiceCollectionExtensions
    {
        public static void AddSolicitorsHttpClient( this IServiceCollection services, string httpClientName, string solicitorsBaseAddress )
        {
            services.AddHttpClient(
                    httpClientName,
                        client =>
                            {
                                // Set the base address of the named client.
                                client.BaseAddress = new Uri( solicitorsBaseAddress );
                                client.DefaultRequestHeaders.UserAgent.ParseAdd( "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/124.0.0.0 Safari/537.36" ); 
                                client.DefaultRequestHeaders.Accept.ParseAdd( "text/html" );
                                client.DefaultRequestHeaders.AcceptEncoding.ParseAdd( "gzip, deflate, br" );
                                client.DefaultRequestHeaders.AcceptLanguage.ParseAdd( "en-US,en;q=0.9" );
                            } )
                .ConfigurePrimaryHttpMessageHandler( () => new HttpClientHandler
                {
                    AutomaticDecompression =
                    DecompressionMethods.GZip |
                    DecompressionMethods.Deflate |
                    DecompressionMethods.Brotli
                } );
        }
    }
}
