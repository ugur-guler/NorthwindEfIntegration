using DataAccess.Abstract;
using DataAccess.Concrete.EFDao;

internal class Program
{
    private static void Main(string[] args)
    {
        IProductDao productDao = new EFProductDao();
        foreach (var product in productDao.GetProductDetails())
        {
            Console.WriteLine(product.ProductId+" -- " + product.ProductName+" -- "+product.CategoryName);
        }
    }
}