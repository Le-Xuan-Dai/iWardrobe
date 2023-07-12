using BusinessObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class OrderServices : RepositoryBase<Order>
    {
            private readonly IWardrobeContext _dbContext;
            private readonly DbSet<Order> _dbSet;
            public OrderServices(IWardrobeContext dBContext) : base(dBContext)
            {
                _dbContext = dBContext;
                _dbSet = _dbContext.Set<Order>();
            }
    }
}
