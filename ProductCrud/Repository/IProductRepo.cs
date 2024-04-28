using ProductCrud.Models;

namespace ProductCrud.Repository
{
    public interface IProductRepo
    {
        Product Find(int id);
        IEnumerable<Product> GetAll();

        Product Add(Product product);
        Product Update(Product product);
        void Remove(int id);
    }
}
