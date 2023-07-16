using BusinessObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CartDetailServices : RepositoryBase<CartDetail>
    {

            private readonly IWardrobeContext _dbContext;
            private readonly DbSet<CartDetail> _dbSet;
            public CartDetailServices(IWardrobeContext dBContext) : base(dBContext)
            {
                _dbContext = dBContext;
                _dbSet = _dbContext.Set<CartDetail>();
            }
        
    }
}
