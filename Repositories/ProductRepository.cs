using BusinessObjects;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class ProductRepository : IProductRepository
    {
        public Product GetProductById(int productId)
        {
            return ProductDAO.Instance.GetProductById(productId);
        }

        public IEnumerable<Product> GetProducts()
        {
            return ProductDAO.Instance.GetProductList();
        }

        public void InsertProduct(Product product)
        {
            ProductDAO.Instance.Insert(product);
        }

        public void UpdateProduct(Product product)
        {
            ProductDAO.Instance.Update(product);
        }
        public void DeleteProduct(int productId)
        {
            ProductDAO.Instance.Remove(productId);


        }

    }
}
