﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MarketPlaceApi.Models;
using MarketPlaceApi.Models.Entities;
using MarketPlaceApi.DTO.Requests;
namespace MarketPlaceApi.Services
{
    public interface IPointsService
    {
        Task<Point> AddPoint(CreatePointRequest createPointRequest);
        Task<Point> UpdatePoint(UpdatePointRequest updatePointRequest);
        Task<IEnumerable<Point>> GetPoints();
        Task<Point> GetPoint(Guid id);
        Task RemovePoint(Guid id);
    }
    public class PointsService : IPointsService
    {
        private readonly ILogger<PointsService> _logger;
        private readonly MarketPlaceContext _MarketPlaceContext;

        public PointsService(MarketPlaceContext marketPlaceContext, ILogger<PointsService> logger)
        {
            _logger = logger;
            _MarketPlaceContext = marketPlaceContext;
        }

        public async Task<Point> AddPoint(CreatePointRequest createPointRequest)
        {
            var point = new Point
            {
                Id = Guid.NewGuid(),
                Description = createPointRequest.Description,
                Name = createPointRequest.Name,
                ObjectType = createPointRequest.ObjectType,
                ObjectId = createPointRequest.ObjectId,
                AssetId = createPointRequest.AssetId,
                Archive = createPointRequest.Archive,
                LastUpdated = createPointRequest.LastUpdated,
                AddedBy = createPointRequest.AddedBy
            };

            if (createPointRequest.DeviceId != null)
            {
                var device = await _MarketPlaceContext.Devices.FindAsync(createPointRequest.DeviceId.Value);
                point.Device = device;
            }
            _MarketPlaceContext.Points.Add(point);
            await _MarketPlaceContext.SaveChangesAsync();

            return point;
        }

        public async Task<Point> UpdatePoint(UpdatePointRequest updatePointRequest)
        {
            var existingPoint = await _MarketPlaceContext.Points.FindAsync(updatePointRequest.Id);
            if (existingPoint != null)
            {
                existingPoint.Description = updatePointRequest.Description;
                existingPoint.Name = updatePointRequest.Name;
                existingPoint.ObjectType = updatePointRequest.ObjectType;
                existingPoint.ObjectId = updatePointRequest.ObjectId;
                existingPoint.AssetId = updatePointRequest.AssetId;
                existingPoint.Archive = updatePointRequest.Archive;
                existingPoint.LastUpdated = updatePointRequest.LastUpdated;
                existingPoint.AddedBy = updatePointRequest.AddedBy;

                if (updatePointRequest.DeviceId != null)
                {
                    var device = await _MarketPlaceContext.Devices.FindAsync(updatePointRequest.DeviceId);
                    existingPoint.Device = device;
                }

                _MarketPlaceContext.Points.Update(existingPoint);
                await _MarketPlaceContext.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException();
            }
            return existingPoint;
        }

        public async Task<IEnumerable<Point>> GetPoints()
        {
            return await _MarketPlaceContext.Points.ToListAsync();
        }

        public async Task<Point> GetPoint(Guid id)
        {
            return await _MarketPlaceContext.Points.FindAsync(id);
        }

        public async Task RemovePoint(Guid id)
        {
            var existingPoint = await _MarketPlaceContext.Points.FindAsync(id);
            if (existingPoint != null)
            {
                _MarketPlaceContext.Points.Remove(existingPoint);
                await _MarketPlaceContext.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException();
            }
        }
    }
}
