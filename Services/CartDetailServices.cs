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
using System.Xml;

namespace Services
{
    public class CartDetailServices : ICartDetailServices
    {
        private readonly CartDetailRepository _repository;

        public CartDetailServices(IWardrobeContext dBContext) 
        {
            _repository = new CartDetailRepository(dBContext);
        }

        public async Task Create(CartDetail item)
        {
            await _repository.Create(item);
        }

        public async Task Delete(CartDetail item)
        {
            await _repository.Delete(item);
        }

        public async Task DeleteById(object id)
        {
            await _repository.DeleteById(id);
        }

        public CartDetail FirstOrDefault(Expression<Func<CartDetail, bool>> predicate, string includeProperties = "") => _repository.FirstOrDefault(predicate, includeProperties);

        public IQueryable<CartDetail> GetAll() => _repository.GetAll();

        public CartDetail GetById(object id) => _repository.GetById(id);

        public async Task Update(CartDetail item)
        {
           await _repository.Update(item);
        }
    }
}
