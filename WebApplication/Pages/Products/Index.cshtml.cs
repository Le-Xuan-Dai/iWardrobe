using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObjects;
using Microsoft.Extensions.Configuration;
using Services;
using WebApplication.Data;

namespace WebApplication.Pages.Products
{
    public class IndexModel : PageModel
    {
        private readonly ProductServices _productServices;
        private readonly IConfiguration Configuration;

        public IndexModel(ProductServices productServices, IConfiguration configuration)
        {
            _productServices = productServices;
            Configuration = configuration;
        }

        public string NameSort { get; set; }
        public string DateSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }
        public PaginatedList<Product> Products { get; set; }

        public async Task OnGetAsync(string sortOrder, string currentFilter, string searchString, int? pageIndex)
        {
            CurrentSort = sortOrder;
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            DateSort = sortOrder == "date" ? "date_desc" : "date";

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

            switch (sortOrder)
            {
                case "name_desc":
                    productsIQ = productsIQ.OrderByDescending(s => s.ProductName);
                    break;
                case "date":
                    productsIQ = productsIQ.OrderBy(s => s.CreationDate);
                    break;
                case "date_desc":
                    productsIQ = productsIQ.OrderByDescending(s => s.CreationDate);
                    break;
                default:
                    productsIQ = productsIQ.OrderBy(s => s.ProductName);
                    break;
            }

            var pageSize = Configuration.GetValue("PageSize", 1);
            Products = await PaginatedList<Product>.CreateAsync(
                productsIQ.AsNoTracking(), pageIndex ?? 1, pageSize);
        }
    }
}
