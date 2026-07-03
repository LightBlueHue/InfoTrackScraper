using InfoTrackScraper.Domain;
using System.Text.RegularExpressions;

namespace InfoTrackScraper.Application
{
    public class SolicitorScraperService : ISolicitorScraperService
    {
        public List<Solicitor> GetSolicitors( string htmlData )
        {
            if ( string.IsNullOrEmpty( htmlData ) )
            {
                throw new ArgumentException( "HTML data cannot be null or empty.", nameof( htmlData ) );
            }

            var solicitorTags = Regex.Split( htmlData, @"<div class=""result-item[^""]*"">" ).Skip( 1 )
                      .Select( b => b.Split( "</div>" )[ 0 ] );

            var solicitors = new List<Solicitor>();

            foreach ( var tag in solicitorTags )
            {
                var solicitor = new Solicitor();

                var nameMatch = Regex.Match( tag, @"<span class=""h2"">(.*?)<" ).Groups[ 1 ];
                solicitor.Name = nameMatch.Success ? nameMatch.Value : string.Empty;

                solicitors.Add( solicitor );
            }

            return solicitors;
        }
    }
}
