using AuthenticationPlugin;
using RestApiSample.Models;
using RestApiSample.Interfaces;

namespace RestApiSample.Services
{

    public class UserService : IUserService
    {
        private readonly ApiDbContext _dbContext;

        public UserService(ApiDbContext dbContext)
        {
            _dbContext = dbContext;


        }

        public void initUserAdmin()
        {
            var user = new User
            {
                Email = "admin@gmail.com",
                Password = "123456",
                Address = "admin location",
                Role = "admin",
                CreatedBy = "admin"
            };

            var getUser = _dbContext.User.FirstOrDefault(u => u.Email == user.Email);

            if (getUser is null)
            {
                Console.WriteLine("getUser is null = {0}", user.CreatedBy);
                createUser(user);

            }

            Console.WriteLine("initUserAdmin is Running...");
        }

        public int createUser(User user)
        {

            string hashed = SecurePasswordHasherHelper.Hash(user.Password);

            user.Password = hashed;

            // var createUser = new User
            // {
            //     Email = user.Email,
            //     Password = hashed,
            //     Role = "user",
            //     Address = "test",
            //     CreatedBy = "admin"
            // };


            _dbContext.Add(user);
            var saveUser = _dbContext.SaveChanges();
            return saveUser;
        }

        public List<User> getUsers()
        {

            return _dbContext.User.ToList();
        }

        public User? getUser(int id)
        {
            var result = _dbContext.User.AsQueryable().FirstOrDefault(user => user.Id == id);

            return result;
        }

        public User? getUserByEmail(string email)
        {
            var result = _dbContext.User.AsQueryable().FirstOrDefault(user => user.Email == email);

            if (result is null)
            {
                return null;
            }

            return result;
        }

        public async Task<int?> updateUser(int id, User user)
        {
            var result = _dbContext.User.AsQueryable().FirstOrDefault(user => user.Id == id);

            if (result is null)
            {
                return null;
            }

            result.Email = user.Email;
            result.Address = user.Address;
            result.Active = user.Active;
            result.Role = user.Role;

            return await _dbContext.SaveChangesAsync();


        }

        public async Task<int?> deleteUser(int id)
        {
            var user = _dbContext.User.FirstOrDefault(user => user.Id == id);

            if (user is null)
            {
                return null;
            }

            _dbContext.Remove(user);
            return await _dbContext.SaveChangesAsync();
        }

    }


}
