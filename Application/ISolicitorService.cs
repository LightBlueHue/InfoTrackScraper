
namespace InfoTrackScraper.Application
{
    public interface ISolicitorService
    {
        Task<string> GetSolicitorsAsync( string location );
    }
}