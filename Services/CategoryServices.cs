using BusinessObjects;
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
    public class CategoryServices : ICategoryServices
    {
        private readonly CategoryRepository _repository;

        public CategoryServices(IWardrobeContext dBContext)
        {
            _repository = new CategoryRepository(dBContext);
        }

        public async Task Create(Category item)
        {
            await _repository.Create(item);
        }

        public async Task Delete(Category item)
        {
            await _repository.Delete(item);
        }

        public async Task DeleteById(object id)
        {
            await _repository.DeleteById(id);
        }

        public Category FirstOrDefault(Expression<Func<Category, bool>> predicate, string includeProperties = "") => _repository.FirstOrDefault(predicate, includeProperties);

        public IQueryable<Category> GetAll() => _repository.GetAll();

        public Category GetById(object id) => _repository.GetById(id);

        public async Task Update(Category item)
        {
            await _repository.Update(item);
        }
    }
}
