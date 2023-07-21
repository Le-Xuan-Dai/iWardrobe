using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IFavoriteServices
    {
        IQueryable<Favorite> GetAll();
        Favorite GetById(object id);
        Task Create(Favorite item);
        Task Update(Favorite item);
        Task Delete(Favorite item);
        Task DeleteById(object id);
        Favorite FirstOrDefault(Expression<Func<Favorite, bool>> predicate, string includeProperties = "");
    }
}
