using Core.ForDataAcces;
using Core.ForEntities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IProductDao:IEntityDao<Product>
    {
        List<ProductDetailsDto> GetProductDetails();
    }
}
