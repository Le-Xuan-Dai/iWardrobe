using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CartDetailServices : RepositoryBase<CartDetail>
    {
        public CartDetailServices(IWardrobeContext dBContext) : base(dBContext)
        {
        }
    }
}
