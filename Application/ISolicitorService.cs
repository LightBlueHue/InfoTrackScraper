
using InfoTrackScraper.Domain;

namespace InfoTrackScraper.Application
{
    public interface ISolicitorService
    {
        Task<List<Solicitor>> GetSolicitorsAsync( string location );
    }
}