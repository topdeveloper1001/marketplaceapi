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
        Task<Device> CreateDevice(CreateDeviceRequest createDeviceRequest);
        Task<Device> UpdateDevice(Guid deviceId, UpdateDeviceRequest updateDeviceRequest);
        Task<IList<Device>> GetDevices();
        Task<Device> GetDevice(Guid deviceId);
        Task DeleteDevice(Guid deviceId);
    }

    public class DevicesService : IDevicesService
    {
        private readonly ILogger<DevicesService> _logger;
        private readonly MarketPlaceContext _dbContext;

        public DevicesService(MarketPlaceContext marketPlaceContext, ILogger<DevicesService> logger)
        {
            _logger = logger;
            _dbContext = marketPlaceContext;
        }

        public async Task<Device> CreateDevice(CreateDeviceRequest createDeviceRequest)
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

            _dbContext.Devices.Add(device);
            await _dbContext.SaveChangesAsync();

            return device;
        }

        public async Task<Device> UpdateDevice(Guid deviceId, UpdateDeviceRequest updateDeviceRequest)
        {
            var existingDevice = await _dbContext.Devices.AsTracking().FirstOrDefaultAsync(d => d.Id == deviceId);
            if (existingDevice == null)
            {
                throw new KeyNotFoundException();
            }

            existingDevice.DeviceIdentifier = updateDeviceRequest.DeviceIdentifier;
            existingDevice.IpAddress = updateDeviceRequest.IpAddress;
            existingDevice.Type = updateDeviceRequest.Type;
            existingDevice.ClientId = updateDeviceRequest.ClientId;
            existingDevice.BuildingId = updateDeviceRequest.BuildingId;

            _dbContext.Devices.Update(existingDevice);
            await _dbContext.SaveChangesAsync();
            return existingDevice;
        }

        public async Task<IList<Device>> GetDevices()
        {
            return await _dbContext.Devices.ToListAsync();
        }

        public async Task<Device> GetDevice(Guid deviceId)
        {
            return await _dbContext.Devices.FindAsync(deviceId);
        }

        public async Task DeleteDevice(Guid deviceId)
        {
            var existingDevice = await _dbContext.Devices.AsTracking().FirstOrDefaultAsync(d => d.Id == deviceId);
            if (existingDevice == null)
            {
                throw new KeyNotFoundException();
            }

            _dbContext.Devices.Remove(existingDevice);
            await _dbContext.SaveChangesAsync();
        }
    }
}
