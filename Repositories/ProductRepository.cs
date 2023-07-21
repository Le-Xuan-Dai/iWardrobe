using BusinessObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class ProductRepository : BaseRepository<Product>
    {
        private readonly IWardrobeContext _dbContext;
        private readonly DbSet<Product> _dbSet;
        public ProductRepository(IWardrobeContext dBContext) : base(dBContext)
        {
            _dbContext = dBContext;
            _dbSet = _dbContext.Set<Product>();
        }
    }
}
