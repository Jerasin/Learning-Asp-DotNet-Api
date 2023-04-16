using RestApiSample.Models;

namespace RestApiSample.Interfaces
{

    public interface IProductService
    {
        public void initProduct();

        public int createProduct(Product product);

        public List<Product> getProducts();

        public Product? getProduct(int id);

        public Task<int?> updateProduct(int id, Product product);

        public Task<int?> deleteProduct(int id);
    }
}