using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MarketPlaceApi.DTO;
using MarketPlaceApi.DTO.Requests;
using MarketPlaceApi.Services;

namespace MarketPlaceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PointsController : ControllerBase
    {
        private readonly IPointsService _pointsService;
        private readonly ILogger<PointsController> _logger;

        public PointsController(IPointsService pointsService, ILogger<PointsController> logger)
        {
            _pointsService = pointsService;
            _logger = logger;
        }

        [HttpPost("AddPoint")]
        [ProducesResponseType(typeof(PointDto), (int)HttpStatusCode.OK)]
        [Produces("application/json")]
        public async Task<IActionResult> AddPoint([FromBody] CreatePointRequest createPointRequest)
        {
            var point = await _pointsService.AddPoint(createPointRequest);
            return Ok(PointDto.Map(point));
        }

        [HttpPost("UpdatePoint")]
        [ProducesResponseType(typeof(PointDto), (int)HttpStatusCode.OK)]
        [Produces("application/json")]
        public async Task<IActionResult> UpdatePoint([FromBody] UpdatePointRequest updatePointRequest)
        {
            var point = await _pointsService.UpdatePoint(updatePointRequest);
            return Ok(PointDto.Map(point));
        }

        [HttpDelete("RemovePoint")]
        [Produces("application/json")]
        public async Task<IActionResult> RemovePoint([FromBody] Guid id)
        {
            await _pointsService.RemovePoint(id);
            return Ok();
        }

        [HttpGet("GetPoint/{id}")]
        [Produces("application/json")]
        public async Task<IActionResult> GetPoint(Guid id)
        {
            return Ok(await _pointsService.GetPoint(id));
        }

        [HttpGet("GetPoints")]
        [Produces("application/json")]
        public async Task<IActionResult> GetPoints()
        {
            return Ok(await _pointsService.GetPoints());
        }
    }
}
