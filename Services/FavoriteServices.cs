using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class FavoriteServices : RepositoryBase<Favorite>
    {
        public FavoriteServices(IWardrobeContext dBContext) : base(dBContext)
        {
        }
    }
}
