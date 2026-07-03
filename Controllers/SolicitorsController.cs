using InfoTrackScraper.Application;
using InfoTrackScraper.Domain;
using Microsoft.AspNetCore.Mvc;

namespace InfoTrackScraper.Controllers
{
    [ApiController]
    [Route( "[controller]" )]
    public class SolicitorsController : ControllerBase
    {
        private readonly ILogger<SolicitorsController> _logger;
        private readonly ISolicitorService _solicitorService;

        public SolicitorsController( ILogger<SolicitorsController> logger, ISolicitorService solicitorService )
        {
            _logger = logger;
            _solicitorService = solicitorService;
        }

        [HttpPost( "{location}" )]
        public async Task<List<Solicitor>> GetSolicitors( string location )
        {
            var data = await _solicitorService.GetSolicitorsAsync( location );
            return data;
        }
    }
}
