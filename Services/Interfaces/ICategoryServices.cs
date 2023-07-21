using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface ICategoryServices
    {
        IQueryable<Category> GetAll();
        Category GetById(object id);
        Task Create(Category item);
        Task Update(Category item);
        Task Delete(Category item);
        Task DeleteById(object id);
        Category FirstOrDefault(Expression<Func<Category, bool>> predicate, string includeProperties = "");
    }
}
