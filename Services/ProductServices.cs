using BusinessObjects;
using Microsoft.EntityFrameworkCore;
using Repositories;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ProductServices : IProductServices
    {
        private readonly ProductRepository _repository;

        public ProductServices(IWardrobeContext dBContext)
        {
            _repository = new ProductRepository(dBContext);
        }
        public async Task Create(Product item)
        {
            await _repository.Create(item);
        }

        public async Task Delete(Product item)
        {
            await _repository.Delete(item);
        }

        public async Task DeleteById(object id)
        {
            await _repository.DeleteById(id);
        }

        public Product FirstOrDefault(Expression<Func<Product, bool>> predicate, string includeProperties = "") => _repository.FirstOrDefault(predicate, includeProperties);

        public IQueryable<Product> GetAll() => _repository.GetAll();

        public Product GetById(object id) => _repository.GetById(id);

        public async Task Update(Product item)
        {
            await _repository.Update(item);
        }
    }
}
