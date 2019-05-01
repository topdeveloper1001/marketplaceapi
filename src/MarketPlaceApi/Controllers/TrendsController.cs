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
    public class TrendsController : ControllerBase
    {
        private readonly ITrendsService _trendsService;
        private readonly ILogger<TrendsController> _logger;

        public TrendsController(ITrendsService trendsService, ILogger<TrendsController> logger)
        {
            _trendsService = trendsService;
            _logger = logger;
        }

        [HttpPost("AddTrend")]
        [ProducesResponseType(typeof(TrendDto), (int)HttpStatusCode.OK)]
        [Produces("application/json")]
        public async Task<IActionResult> AddTrend([FromBody] CreateTrendRequest createTrendRequest)
        {
            var trend = await _trendsService.AddTrend(createTrendRequest);
            return Ok(TrendDto.Map(trend));
        }

        [HttpPost("UpdateTrend")]
        [ProducesResponseType(typeof(TrendDto), (int)HttpStatusCode.OK)]
        [Produces("application/json")]
        public async Task<IActionResult> UpdateTrend([FromBody] UpdateTrendRequest updateTrendRequest)
        {
            var trend = await _trendsService.UpdateTrend(updateTrendRequest);
            return Ok(TrendDto.Map(trend));
        }

        [HttpDelete("RemoveTrend")]
        [Produces("application/json")]
        public async Task<IActionResult> RemoveTrend([FromBody] Guid id)
        {
            await _trendsService.RemoveTrend(id);
            return Ok();
        }

        [HttpGet("GetTrend/{id}")]
        [Produces("application/json")]
        public async Task<IActionResult> GetTrend(Guid id)
        {
            return Ok(await _trendsService.GetTrend(id));
        }

        [HttpGet("GetTrends")]
        [Produces("application/json")]
        public async Task<IActionResult> GetTrends()
        {
            return Ok(await _trendsService.GetTrends());
        }
    }
}
