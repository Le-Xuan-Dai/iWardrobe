using BusinessObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class CommentRepository : BaseRepository<Comment>
    {
        private readonly IWardrobeContext _dbContext;
        private readonly DbSet<Comment> _dbSet;
        public CommentRepository(IWardrobeContext dBContext) : base(dBContext)
        {
            _dbContext = dBContext;
            _dbSet = _dbContext.Set<Comment>();
        }
    }
}
