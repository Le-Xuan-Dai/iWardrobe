using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class OrderServices : RepositoryBase<Order>
    {
        public OrderServices(IWardrobeContext dBContext) : base(dBContext)
        {
        }
    }
}
