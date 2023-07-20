using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface ICommentServices
    {
        IQueryable<Comment> GetAll();
        Comment GetById(object id);
        Task Create(Comment item);
        Task Update(Comment item);
        Task Delete(Comment item);
        Task DeleteById(object id);
        Comment FirstOrDefault(Expression<Func<Comment, bool>> predicate, string includeProperties = "");
    }
}
