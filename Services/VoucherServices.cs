using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class VoucherServices : RepositoryBase<Voucher>
    {
        public VoucherServices(IWardrobeContext dBContext) : base(dBContext)
        {
        }
    }
}
