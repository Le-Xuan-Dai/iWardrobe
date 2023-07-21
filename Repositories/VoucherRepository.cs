using BusinessObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class VoucherRepository : BaseRepository<Voucher>
    {
        private readonly IWardrobeContext _dbContext;
        private readonly DbSet<Voucher> _dbSet;
        public VoucherRepository(IWardrobeContext dBContext) : base(dBContext)
        {
            _dbContext = dBContext;
            _dbSet = _dbContext.Set<Voucher>();
        }
    }
}
