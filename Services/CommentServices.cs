using BusinessObjects;
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
    public class CommentServices : ICommentServices
    {
        private readonly CommentRepository _repository;

        public CommentServices(IWardrobeContext dBContext)
        {
            _repository = new CommentRepository(dBContext);
        }
        public async Task Create(Comment item)
        {
            await _repository.Create(item);
        }

        public async Task Delete(Comment item)
        {
            await _repository.Delete(item);
        }

        public async Task DeleteById(object id)
        {
            await _repository.DeleteById(id);
        }

        public Comment FirstOrDefault(Expression<Func<Comment, bool>> predicate, string includeProperties = "") => _repository.FirstOrDefault(predicate, includeProperties);

        public IQueryable<Comment> GetAll() => _repository.GetAll();

        public Comment GetById(object id) => _repository.GetById(id);

        public async Task Update(Comment item)
        {
            await _repository.Update(item);
        }
    }
}
