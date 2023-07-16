using BusinessObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class VoucherServices : RepositoryBase<Voucher>
    {
            private readonly IWardrobeContext _dbContext;
            private readonly DbSet<Voucher> _dbSet;
            public VoucherServices(IWardrobeContext dBContext) : base(dBContext)
            {
                _dbContext = dBContext;
                _dbSet = _dbContext.Set<Voucher>(); 
            }
    }
}
