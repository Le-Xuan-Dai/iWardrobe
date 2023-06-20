using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class ProductDAO
    {

        //USing Singleton Pattern
        private static ProductDAO instance = null;
        private static readonly object instanceLock = new object();

        public static ProductDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new ProductDAO();
                    }
                    return instance;
                }
            }
        }

        public IEnumerable<Product> GetProductList()
        {
            var Products = new List<Product>();
            try
            {
                using var context = new IWardboreContext();
                Products = context.Products.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return Products;
        }

        public Product GetProductById(int ProductId)
        {
            Product Product = null;
            try
            {
                using var context = new IWardboreContext();
                Product = context.Products.SingleOrDefault(c => c.ProductId == ProductId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return Product;

        }

        public void Insert(Product Product)
        {
            try
            {
                Product newProduct = GetProductById(Product.ProductId);
                if (Product != null)
                {
                    using var context = new IWardboreContext();
                    context.Products.Add(Product);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The product is already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Update(Product Product)
        {
            try
            {
                Product _Product = GetProductById(Product.ProductId);
                if (_Product != null)
                {
                    using var context = new IWardboreContext();
                    context.Products.Update(Product);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The product does not already exist. ");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Remove(int ProductId)
        {
            try
            {
                Product Product = GetProductById(ProductId);
                if (Product != null)
                {
                    using var context = new IWardboreContext();
                    context.Products.Remove(Product);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The product does not already exist. ");
                }
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


    }
}
