using InfoTrackScraper.Domain;

namespace InfoTrackScraper.Application
{
    public interface ISolicitorScraperService
    {
        List<Solicitor> GetSolicitors( string htmlData );
    }
}