using BusinessObjects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Data;

namespace WebApplication.Pages
{
    public class HomeModel : PageModel
    {
        private readonly ProductServices _productServices;
        private readonly IConfiguration Configuration;

        public HomeModel(ProductServices productServices, IConfiguration configuration)
        {
            _productServices = productServices;
            Configuration = configuration;
        }

        public PaginatedList<Product> Products { get; set; }
        public string CurrentFilter { get; set; }

        public async Task OnGetAsync(string searchString, string currentFilter, int? pageIndex)
        {
            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            CurrentFilter = searchString;

            IQueryable<Product> productsIQ = _productServices.GetAll();

            if (!String.IsNullOrEmpty(searchString))
            {
                productsIQ = productsIQ.Where(s => s.ProductName.Contains(searchString));
            }

            var pageSize = Configuration.GetValue("PageSize", 1);
            Products = await PaginatedList<Product>.CreateAsync(
                productsIQ.AsNoTracking(), pageIndex ?? 1, pageSize);
        }
    }
}
