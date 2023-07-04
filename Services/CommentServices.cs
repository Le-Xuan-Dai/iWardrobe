using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CommentServices : RepositoryBase<Commnent>
    {
        public CommentServices(IWardrobeContext dBContext) : base(dBContext)
        {
        }
    }
}
