using RestApiSample.src.Models;
using RestApiSample.src.Services;

namespace RestApiSample.src.Interfaces
{
    public class IWareHouse
    {
        public int Amount { get; set; }
        public int ProductId { get; set; }
    }

    public interface IWareHouseService
    {
        public void initWareHouse();

        public int createWareHouse(WareHouse wareHouse);

        public FormatResponseService getWareHouses();

        public WareHouse? getWareHouse(int id);

        public Task<int?> updateWareHouse(int id, WareHouse wareHouse);

        public Task<int?> deleteWareHouse(int id);

        public IQueryable WareHouseProducts();

        public List<WareHouse>? ContextWareHouseProducts();
    }
}