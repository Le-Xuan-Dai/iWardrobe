using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CategoryServices : RepositoryBase<Category>
    {
        public CategoryServices(IWardrobeContext dBContext) : base(dBContext)
        {
        }
    }
}
