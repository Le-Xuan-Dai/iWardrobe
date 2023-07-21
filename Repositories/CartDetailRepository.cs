using BusinessObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class CartDetailRepository : BaseRepository<CartDetail>
    {
        private readonly IWardrobeContext _dbContext;
        private readonly DbSet<CartDetail> _dbSet;
        public CartDetailRepository(IWardrobeContext dBContext) : base(dBContext)
        {
            _dbContext = dBContext;
            _dbSet = _dbContext.Set<CartDetail>();
        }
    }
}
