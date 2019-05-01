using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MarketPlaceApi.Models;
using MarketPlaceApi.Models.Entities;
using MarketPlaceApi.DTO.Requests;
namespace MarketPlaceApi.Services
{
    public interface IDevicesService
    {
        Task<Device> AddDevice(CreateDeviceRequest createDeviceRequest);
        Task<Device> UpdateDevice(UpdateDeviceRequest updateDeviceRequest);
        Task<IEnumerable<Device>> GetDevices();
        Task<Device> GetDevice(Guid id);
        Task RemoveDevice(Guid id);
    }
    public class DevicesService : IDevicesService
    {
        private readonly ILogger<DevicesService> _logger;
        private readonly MarketPlaceContext _MarketPlaceContext;

        public DevicesService(MarketPlaceContext marketPlaceContext, ILogger<DevicesService> logger)
        {
            _logger = logger;
            _MarketPlaceContext = marketPlaceContext;
        }

        public async Task<Device> AddDevice(CreateDeviceRequest createDeviceRequest)
        {
            var device = new Device
            {
                Id = Guid.NewGuid(),
                DeviceIdentifier = createDeviceRequest.DeviceIdentifier,
                IpAddress = createDeviceRequest.IpAddress,
                Type = createDeviceRequest.Type,
                ClientId = createDeviceRequest.ClientId,
                BuildingId = createDeviceRequest.BuildingId
            };

            _MarketPlaceContext.Devices.Add(device);
            await _MarketPlaceContext.SaveChangesAsync();

            return device;
        }

        public async Task<Device> UpdateDevice(UpdateDeviceRequest updateDeviceRequest)
        {
            var existingDevice = await _MarketPlaceContext.Devices.FindAsync(updateDeviceRequest.Id);
            if (existingDevice != null)
            {
                existingDevice.DeviceIdentifier = updateDeviceRequest.DeviceIdentifier;
                existingDevice.IpAddress = updateDeviceRequest.IpAddress;
                existingDevice.Type = updateDeviceRequest.Type;
                existingDevice.ClientId = updateDeviceRequest.ClientId;
                existingDevice.BuildingId = updateDeviceRequest.BuildingId;
                
                _MarketPlaceContext.Devices.Update(existingDevice);
                await _MarketPlaceContext.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException();
            }
            return existingDevice;
        }

        public async Task<IEnumerable<Device>> GetDevices()
        {
            return await _MarketPlaceContext.Devices.ToListAsync();
        }

        public async Task<Device> GetDevice(Guid id)
        {
            return await _MarketPlaceContext.Devices.FindAsync(id);
        }

        public async Task RemoveDevice(Guid id)
        {
            var existingDevice = await _MarketPlaceContext.Devices.FindAsync(id);
            if (existingDevice != null)
            {
                _MarketPlaceContext.Devices.Remove(existingDevice);
                await _MarketPlaceContext.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException();
            }
        }
    }
}
