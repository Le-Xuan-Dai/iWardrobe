using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IVoucherServices
    {
        IQueryable<Voucher> GetAll();
        Voucher GetById(object id);
        Task Create(Voucher item);
        Task Update(Voucher item);
        Task Delete(Voucher item);
        Task DeleteById(object id);
        Voucher FirstOrDefault(Expression<Func<Voucher, bool>> predicate, string includeProperties = "");
    }
}
