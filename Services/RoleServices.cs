using BusinessObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class RoleServices : RepositoryBase<Role>
    {
        private readonly IWardrobeContext _dbContext;
        private readonly DbSet<Role> _dbSet;
        public RoleServices(IWardrobeContext dBContext) : base(dBContext)
        {
            _dbContext = dBContext;
            _dbSet = _dbContext.Set<Role>();
        }
    }
}
