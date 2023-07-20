using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface ICartDetailServices
    {
        IQueryable<CartDetail> GetAll();
        CartDetail GetById(object id);
        Task Create(CartDetail item);
        Task Update(CartDetail item);
        Task Delete(CartDetail item);
        Task DeleteById(object id);
        CartDetail FirstOrDefault(Expression<Func<CartDetail, bool>> predicate, string includeProperties = "");
    }
}
