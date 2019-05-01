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
    public class DevicesController : ControllerBase
    {
        private readonly IDevicesService _devicesService;
        private readonly ILogger<DevicesController> _logger;

        public DevicesController(IDevicesService devicesService, ILogger<DevicesController> logger)
        {
            _devicesService = devicesService;
            _logger = logger;
        }

        [HttpPost("AddDevice")]
        [ProducesResponseType(typeof(DeviceDto), (int)HttpStatusCode.OK)]
        [Produces("application/json")]
        public async Task<IActionResult> AddDevice([FromBody] CreateDeviceRequest createDeviceRequest)
        {
            var device = await _devicesService.AddDevice(createDeviceRequest);
            return Ok(DeviceDto.Map(device));
        }

        [HttpPost("UpdateDevice")]
        [ProducesResponseType(typeof(DeviceDto), (int)HttpStatusCode.OK)]
        [Produces("application/json")]
        public async Task<IActionResult> UpdateDevice([FromBody] UpdateDeviceRequest updateDeviceRequest)
        {
            var device = await _devicesService.UpdateDevice(updateDeviceRequest);
            return Ok(DeviceDto.Map(device));
        }

        [HttpDelete("RemoveDevice")]
        [Produces("application/json")]
        public async Task<IActionResult> RemoveDevice(Guid id)
        {
            await _devicesService.RemoveDevice(id);
            return Ok();
        }

        [HttpGet("GetDevice/{id}")]
        [Produces("application/json")]
        public async Task<IActionResult> GetDevice(Guid id)
        {
            return Ok(await _devicesService.GetDevice(id));
        }

        [HttpGet("GetDevices")]
        [Produces("application/json")]
        public async Task<IActionResult> GetDevices()
        {
            return Ok(await _devicesService.GetDevices());
        }
    }
}
