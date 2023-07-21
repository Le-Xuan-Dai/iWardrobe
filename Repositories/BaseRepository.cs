using BusinessObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class BaseRepository<T> where T : class
    {
        private readonly IWardrobeContext _dbContext;
        private readonly DbSet<T> _dbSet;
        public BaseRepository(IWardrobeContext dBContext)
        {
            _dbContext = dBContext;
            _dbSet = _dbContext.Set<T>();
        }
        public IQueryable<T> GetAll()
        {
            return _dbSet;
        }
        public T GetById(object id)
        {
            return _dbSet.Find(id);
        }
        public async Task Create(T item)
        {
            _dbSet.Add(item);
            await _dbContext.SaveChangesAsync();
        }
        public async Task Update(T item)
        {
            _dbContext.Attach(item).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
        public async Task Delete(T item)
        {
            _dbSet.Remove(item);
            await _dbContext.SaveChangesAsync();
        }
        public async Task DeleteById(object id)
        {
            T _item = _dbSet.Find(id);

            if (_item != null)
            {
                _dbSet.Remove(_item);
                await _dbContext.SaveChangesAsync();
            }
        }
        public T FirstOrDefault(Expression<Func<T, bool>> predicate, string includeProperties = "")
        {
            IQueryable<T> query = _dbContext.Set<T>();
            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }
            return query.FirstOrDefault(predicate);
        }
    }
}
