using DutchTreat.Data.Entities;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace DutchTreat.Data
{
    public class DutchRepository : IDutchRepository
    {
        private readonly DutchContext context;
        private readonly ILogger<DutchRepository> _logger;

        public DutchRepository(DutchContext context, ILogger<DutchRepository> logger)
        {
            this.context = context;
            _logger = logger;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            try
            {
                _logger.LogInformation($"{nameof(GetAllProducts)} was called");
                return context.Products.OrderBy(p => p.Title).ToList();
            }
            catch (System.Exception ex)
            {
                _logger.LogError($"Failed to get all products: {ex}");
                throw;
            }
        }

        public IEnumerable<Product> GetProductsByCategory(string category)
        {
            try
            {
                _logger.LogInformation($"{nameof(GetProductsByCategory)} was called");
                return context.Products.Where(p => p.Category == category).OrderBy(p => p.Title).ToList();
            }
            catch (System.Exception ex)
            {
                _logger.LogError($"Failed to get products by id: {ex}");
                throw;
            }
        }

        public bool SaveAll()
        {
            try
            {
                _logger.LogInformation($"{nameof(SaveAll)} was called");
                return context.SaveChanges() > 0;
            }
            catch (System.Exception ex)
            {
                _logger.LogError($"Failed to save changes: {ex}");
                throw;
            }
        }
    }
}
