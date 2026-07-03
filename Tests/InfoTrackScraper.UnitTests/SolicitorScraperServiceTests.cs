using InfoTrackScraper.Application;

namespace InfoTrackScraper.UnitTests
{
    public class SolicitorScraperServiceTests
    {
        [Fact]
        public void GetSolicitors_ParsesNamesFromHtml()
        {
            // Arrange
            var html = """
            <div class="result-item">
                <div class="top-holder">
                    <span class="h2">DPH Legal<span class="rev-results"></span></span>
                </div>
            </div>

            <div class="result-item">
                <div class="top-holder">
                    <span class="h2">QualitySolicitors</span>
                </div>
            </div>

            <div class="result-item item-small">
                <span class="h2">Tollers Solicitors</span>
            </div>
        """;

            var scraper = new SolicitorScraperService();

            // Act
            var result = scraper.GetSolicitors( html );

            // Assert
            Assert.Equal( 3, result.Count );

            Assert.Equal( "DPH Legal", result[ 0 ].Name );
            Assert.Equal( "QualitySolicitors", result[ 1 ].Name );
            Assert.Equal( "Tollers Solicitors", result[ 2 ].Name );
        }
    }
}
