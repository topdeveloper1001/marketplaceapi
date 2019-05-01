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
    public interface ITrendsService
    {
        Task<Trend> AddTrend(CreateTrendRequest createTrendRequest);
        Task<Trend> UpdateTrend(UpdateTrendRequest updateTrendRequest);
        Task<IEnumerable<Trend>> GetTrends();
        Task<Trend> GetTrend(Guid id);
        Task RemoveTrend(Guid id);
    }
    public class TrendsService : ITrendsService
    {
        private readonly ILogger<TrendsService> _logger;
        private readonly MarketPlaceContext _MarketPlaceContext;

        public TrendsService(MarketPlaceContext marketPlaceContext, ILogger<TrendsService> logger)
        {
            _logger = logger;
            _MarketPlaceContext = marketPlaceContext;
        }

        public async Task<Trend> AddTrend(CreateTrendRequest createTrendRequest)
        {
            var trend = new Trend
            {
                Id = Guid.NewGuid(),
                Name = createTrendRequest.Name,
                Interval = createTrendRequest.Interval,
                Type = createTrendRequest.Type,
                DateCreated = createTrendRequest.DateCreated,
                TimeOut = createTrendRequest.TimeOut,
                TreadsNumber = createTrendRequest.TreadsNumber
            };

            _MarketPlaceContext.Trends.Add(trend);
            await _MarketPlaceContext.SaveChangesAsync();

            return trend;
        }

        public async Task<Trend> UpdateTrend(UpdateTrendRequest updateTrendRequest)
        {
            var existingTrend = await _MarketPlaceContext.Trends.FindAsync(updateTrendRequest.Id);
            if (existingTrend != null)
            {
                existingTrend.Name = updateTrendRequest.Name;
                existingTrend.Interval = updateTrendRequest.Interval;
                existingTrend.Type = updateTrendRequest.Type;
                existingTrend.DateCreated = updateTrendRequest.DateCreated;
                existingTrend.TimeOut = updateTrendRequest.TimeOut;
                existingTrend.TreadsNumber = updateTrendRequest.TreadsNumber;
                
                _MarketPlaceContext.Trends.Update(existingTrend);
                await _MarketPlaceContext.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException();
            }
            return existingTrend;
        }

        public async Task<IEnumerable<Trend>> GetTrends()
        {
            return await _MarketPlaceContext.Trends.ToListAsync();
        }

        public async Task<Trend> GetTrend(Guid id)
        {
            return await _MarketPlaceContext.Trends.FindAsync(id);
        }

        public async Task RemoveTrend(Guid id)
        {
            var existingTrend = await _MarketPlaceContext.Trends.FindAsync(id);
            if (existingTrend != null)
            {
                _MarketPlaceContext.Trends.Remove(existingTrend);
                await _MarketPlaceContext.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException();
            }
        }
    }
}
