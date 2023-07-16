using BusinessObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ProductServices : RepositoryBase<Product>
    {
        private readonly IWardrobeContext _dbContext;
        private readonly DbSet<Product> _dbSet;
        public ProductServices(IWardrobeContext dBContext) : base(dBContext)
        {
           _dbContext = dBContext;
           _dbSet = _dbContext.Set<Product>();
        }

    }
}
