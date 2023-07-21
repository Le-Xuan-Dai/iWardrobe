using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IUserServices
    {
        IQueryable<User> GetAll();
        User GetById(object id);
        Task Create(User item);
        Task Update(User item);
        Task Delete(User item);
        Task DeleteById(object id);
        User FirstOrDefault(Expression<Func<User, bool>> predicate, string includeProperties = "");
    }
}
