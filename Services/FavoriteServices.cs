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
    public class FavoriteServices : IFavoriteServices
    {
        private readonly FavoriteRepository _repository;

        public FavoriteServices(IWardrobeContext dBContext)
        {
            _repository = new FavoriteRepository(dBContext);
        }
        public async Task Create(Favorite item)
        {
            await _repository.Create(item);
        }

        public async Task Delete(Favorite item)
        {
            await _repository.Delete(item);
        }

        public async Task DeleteById(object id)
        {
            await _repository.DeleteById(id);
        }

        public Favorite FirstOrDefault(Expression<Func<Favorite, bool>> predicate, string includeProperties = "") => _repository.FirstOrDefault(predicate, includeProperties);

        public IQueryable<Favorite> GetAll() => _repository.GetAll();

        public Favorite GetById(object id) => _repository.GetById(id);

        public async Task Update(Favorite item)
        {
            await _repository.Update(item);
        }
    }
}
