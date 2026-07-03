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
