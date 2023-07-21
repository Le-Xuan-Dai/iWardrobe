using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IOrderServices
    {
        IQueryable<Order> GetAll();
        Order GetById(object id);
        Task Create(Order item);
        Task Update(Order item);
        Task Delete(Order item);
        Task DeleteById(object id);
        Order FirstOrDefault(Expression<Func<Order, bool>> predicate, string includeProperties = "");
    }
}
