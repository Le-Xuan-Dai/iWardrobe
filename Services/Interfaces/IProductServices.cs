using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IProductServices
    {
        IQueryable<Product> GetAll();
        Product GetById(object id);
        Task Create(Product item);
        Task Update(Product item);
        Task Delete(Product item);
        Task DeleteById(object id);
        Product FirstOrDefault(Expression<Func<Product, bool>> predicate, string includeProperties = "");
    }
}
