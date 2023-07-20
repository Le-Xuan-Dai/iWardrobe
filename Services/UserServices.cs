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
    public class UserServices : IUserServices
    {
        private readonly UserRepository _repository;

        public UserServices(IWardrobeContext dBContext)
        {
            _repository = new UserRepository(dBContext);
        }
        public async Task Create(User item)
        {
            await _repository.Create(item);
        }

        public async Task Delete(User item)
        {
            await _repository.Delete(item);
        }

        public async Task DeleteById(object id)
        {
            await _repository.DeleteById(id);
        }

        public User FirstOrDefault(Expression<Func<User, bool>> predicate, string includeProperties = "") => _repository.FirstOrDefault(predicate, includeProperties);

        public IQueryable<User> GetAll() => _repository.GetAll();

        public User GetById(object id) => _repository.GetById(id);

        public async Task Update(User item)
        {
            await _repository.Update(item);
        }
    }
}
