using BusinessObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class FavoriteRepository : BaseRepository<Favorite>
    {
        private readonly IWardrobeContext _dbContext;
        private readonly DbSet<Favorite> _dbSet;
        public FavoriteRepository(IWardrobeContext dBContext) : base(dBContext)
        {
            _dbContext = dBContext;
            _dbSet = _dbContext.Set<Favorite>();
        }
    }
}
