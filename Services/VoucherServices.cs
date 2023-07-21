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
    public class VoucherServices : IVoucherServices
    {
        private readonly VoucherRepository _repository;

        public VoucherServices(IWardrobeContext dBContext)
        {
            _repository = new VoucherRepository(dBContext);
        }
        public async Task Create(Voucher item)
        {
            await _repository.Create(item);
        }

        public async Task Delete(Voucher item)
        {
            await _repository.Delete(item);
        }

        public async Task DeleteById(object id)
        {
            await _repository.DeleteById(id);
        }

        public Voucher FirstOrDefault(Expression<Func<Voucher, bool>> predicate, string includeProperties = "") => _repository.FirstOrDefault(predicate, includeProperties);

        public IQueryable<Voucher> GetAll() => _repository.GetAll();

        public Voucher GetById(object id) => _repository.GetById(id);

        public async Task Update(Voucher item)
        {
            await _repository.Update(item);
        }
    }
}
