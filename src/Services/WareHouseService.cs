using RestApiSample.Models;

namespace RestApiSample.Services
{
    public class WareHouseService
    {

        private readonly ApiDbContext _dbContext;

        public WareHouseService(ApiDbContext apiDbContext)
        {
            _dbContext = apiDbContext;
        }

        public void initWareHouse()
        {
            var wareHouse = new WareHouse
            {
                ProductId = 1,
                Amount = 1000,
                CreatedBy = "admin"
            };

            var getWareHouse = _dbContext.WareHouse.FirstOrDefault(u => u.ProductId == wareHouse.ProductId);

            Console.WriteLine("getWareHouse = {0}", getWareHouse);

            if (getWareHouse is null)
            {
                Console.WriteLine("getWareHouse is null");
                createWareHouse(wareHouse);

            }

            Console.WriteLine("initWareHouse is Running...");
        }


        public int createWareHouse(WareHouse wareHouse)
        {
            _dbContext.Add(wareHouse);
            var saveWareHouse = _dbContext.SaveChanges();
            return saveWareHouse;
        }


        public List<WareHouse> getWareHouses()
        {

            return _dbContext.WareHouse.ToList();
        }

        public WareHouse? getWareHouse(int id)
        {
            var result = _dbContext.WareHouse.AsQueryable().FirstOrDefault(wareHouse => wareHouse.Id == id);

            return result;
        }

        public async Task<int?> updateWareHouse(int id, WareHouse wareHouse)
        {
            var result = _dbContext.WareHouse.AsQueryable().FirstOrDefault(wareHouse => wareHouse.Id == id);

            if (result is null)
            {
                return null;
            }

            var props = new WareHouse
            {
                Id = result.Id,
                ProductId = wareHouse.ProductId,
                Amount = wareHouse.Amount,
            };
            _dbContext.Update(props);
            return await _dbContext.SaveChangesAsync();

        }

        public async Task<int?> deleteWareHouse(int id)
        {
            var wareHouse = _dbContext.WareHouse.FirstOrDefault(wareHouse => wareHouse.Id == id);

            if (wareHouse is null)
            {
                return null;
            }

            _dbContext.Remove(wareHouse);
            return await _dbContext.SaveChangesAsync();
        }


        public IQueryable WareHouseProducts()
        {
            var result = from wareHouse in _dbContext.WareHouse
                         join product in _dbContext.Product on wareHouse.ProductId equals product.Id into Products
                         from m in Products.DefaultIfEmpty()
                         select new
                         {
                             id = wareHouse.Id,
                             ProductId = wareHouse.ProductId,
                             ProductName = m.Name,
                             ProductActive = m.Active
                         };

            return result;
        }
    }
}