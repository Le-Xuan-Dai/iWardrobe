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
    public class OrderServices : IOrderServices
    {
        private readonly OrderRepository _repository;

        public OrderServices(IWardrobeContext dBContext)
        {
            _repository = new OrderRepository(dBContext);
        }

        public async Task Create(Order item)
        {
            await _repository.Create(item);
        }

        public async Task Delete(Order item)
        {
            await _repository.Delete(item);
        }

        public async Task DeleteById(object id)
        {
            await _repository.DeleteById(id);
        }

        public Order FirstOrDefault(Expression<Func<Order, bool>> predicate, string includeProperties = "") => _repository.FirstOrDefault(predicate, includeProperties);

        public IQueryable<Order> GetAll() => _repository.GetAll();

        public Order GetById(object id) => _repository.GetById(id);

        public async Task Update(Order item)
        {
            await _repository.Update(item);
        }
    }
}
