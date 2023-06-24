using BusinessObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class UserServices : RepositoryBase<User>
    {
        private readonly IWardrobeContext _dbContext;
        private readonly DbSet<User> _dbSet;
        public UserServices(IWardrobeContext dBContext) : base(dBContext)
        {
            _dbContext = dBContext;
            _dbSet = _dbContext.Set<User>();
        }
    }
}
