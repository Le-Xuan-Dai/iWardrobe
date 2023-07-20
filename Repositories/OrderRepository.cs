using BusinessObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class OrderRepository : BaseRepository<Order>
    {
        private readonly IWardrobeContext _dbContext;
        private readonly DbSet<Order> _dbSet;
        public OrderRepository(IWardrobeContext dBContext) : base(dBContext)
        {
            _dbContext = dBContext;
            _dbSet = _dbContext.Set<Order>();
        }
    }
}
