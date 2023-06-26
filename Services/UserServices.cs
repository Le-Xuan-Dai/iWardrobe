using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class UserServices : RepositoryBase<User>
    {
        public UserServices(IWardrobeContext dBContext) : base(dBContext)
        {
        }
    }
}
