using BusinessObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class CategoryRepository : BaseRepository<Category>
    {
        private readonly IWardrobeContext _dbContext;
        private readonly DbSet<Category> _dbSet;
        public CategoryRepository(IWardrobeContext dBContext) : base(dBContext)
        {
            _dbContext = dBContext;
            _dbSet = _dbContext.Set<Category>();
        }
    }
}
