using RestApiSample.Interfaces;
using RestApiSample.Models;

namespace RestApiSample.Services
{
    public class ProductService : IProductService
    {

        private readonly ApiDbContext _dbContext;

        public ProductService(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void initProduct()
        {
            var product = new Product
            {
                Name = "TV",
                Price = 1500,
                CreatedBy = "admin"
            };

            var getProduct = _dbContext.Product.FirstOrDefault(u => u.Name == product.Name);

            Console.WriteLine("getProduct = {0}", getProduct);

            if (getProduct is null)
            {
                Console.WriteLine("getProduct is null");
                createProduct(product);

            }

            Console.WriteLine("initProduct is Running...");
        }


        public int createProduct(Product product)
        {
            _dbContext.Add(product);
            var saveProduct = _dbContext.SaveChanges();
            return saveProduct;
        }

        public List<Product> getProducts()
        {
            Console.WriteLine("count = {0}", _dbContext.Product.Count());
            return _dbContext.Product.ToList();
        }

        public Product? getProduct(int id)
        {
            return _dbContext.Product.AsQueryable().FirstOrDefault(item => item.Id == id);
        }

        public async Task<int?> updateProduct(int id, Product product)
        {
            var result = _dbContext.Product.AsQueryable().FirstOrDefault(product => product.Id == id);

            if (result is null)
            {
                return null;
            }

            var props = new Product
            {
                Id = result.Id,
                Name = product.Name,
                Price = product.Price,
                Img = product.Img,
                Active = product.Active
            };


            _dbContext.Update(props);
            return await _dbContext.SaveChangesAsync();


        }


        public async Task<int?> deleteProduct(int id)
        {
            var product = _dbContext.User.FirstOrDefault(product => product.Id == id);

            if (product is null)
            {
                return null;
            }

            _dbContext.Remove(product);
            return await _dbContext.SaveChangesAsync();
        }

    }
}