using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MarketPlaceApi.DTO;
using MarketPlaceApi.DTO.Requests;
using MarketPlaceApi.Services;
using System.Collections.Generic;

namespace MarketPlaceApi.Controllers
{
    [ApiConventionType(typeof(DefaultApiConventions))]
    [ApiController]
    [Produces("application/json")]
    public class DevicesController : ControllerBase
    {
        private readonly IDevicesService _devicesService;
        private readonly ILogger<DevicesController> _logger;

        public DevicesController(IDevicesService devicesService, ILogger<DevicesController> logger)
        {
            _devicesService = devicesService;
            _logger = logger;
        }

        [HttpPost("devices")]
        [ProducesResponseType(typeof(DeviceDto), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreateDevice([FromBody] CreateDeviceRequest createDeviceRequest)
        {
            var device = await _devicesService.CreateDevice(createDeviceRequest);
            return Ok(DeviceDto.Map(device));
        }

        [HttpPost("devices/{deviceId}")]
        [ProducesResponseType(typeof(DeviceDto), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateDevice([FromRoute] Guid deviceId, [FromBody] UpdateDeviceRequest updateDeviceRequest)
        {
            var device = await _devicesService.UpdateDevice(deviceId, updateDeviceRequest);
            return Ok(DeviceDto.Map(device));
        }

        [HttpDelete("devices/{deviceId}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> RemoveDevice([FromRoute] Guid deviceId)
        {
            await _devicesService.DeleteDevice(deviceId);
            return NoContent();
        }

        [HttpGet("devices/{deviceId}")]
        [ProducesResponseType(typeof(DeviceDto), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetDevice([FromRoute] Guid deviceId)
        {
            var device = await _devicesService.GetDevice(deviceId);
            return Ok(DeviceDto.Map(device));
        }

        [HttpGet("devices")]
        [ProducesResponseType(typeof(IList<DeviceDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetDevices()
        {
            var devices = await _devicesService.GetDevices();
            return Ok(DeviceDto.Map(devices));
        }
    }
}
