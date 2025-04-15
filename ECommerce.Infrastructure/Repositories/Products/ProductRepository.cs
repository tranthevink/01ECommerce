using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Domain.Entities;
using ECommerce.Domain.Interfaces;

namespace ECommerce.Infrastructure.Repositories.Products
{
    public class ProductRepository : IProductRepository
    {
        public Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetProductByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> GetProductByIdAsync()
        {
            throw new NotImplementedException();
        }

        Task<Domain.Entities.Product> IProductRepository.GetProductByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
