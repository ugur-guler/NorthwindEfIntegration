using Core.ForDataAcces.EFBase;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EFDao
{
    public class EFProductDao : EFBaseDao<Product, NorthwindContext>, IProductDao
    {
        public List<ProductDetailsDto> GetProductDetails()
        {
            using (NorthwindContext context= new NorthwindContext())
            {
                var results = from p in context.Products
                              join c in context.Categories
                              on p.CategoryId equals c.CategoryId
                              select new ProductDetailsDto
                              {
                                  ProductId = p.ProductId,
                                  ProductName = p.ProductName,
                                  CategoryName = c.CategoryName
                              };

                return results.ToList();

            }
        }
    }
}
