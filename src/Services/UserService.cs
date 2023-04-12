using Models.User;
using Models.ApiDbContext;

namespace Services.UserService
{

    public class UserService
    {
        private readonly ApiDbContext _dbContext;

        public UserService(ApiDbContext dbContext) { _dbContext = dbContext; }

        public int createUser(User user)
        {
            _dbContext.Add(user);
            var saveUser = _dbContext.SaveChanges();
            return saveUser;
        }

        public List<User> getUsers()
        {

            var users = _dbContext.User.ToList();
            Console.WriteLine("Test");
            return users;
        }

        public User getUser(int id)
        {
            var user = _dbContext.User.AsQueryable().FirstOrDefault(user => user.id == id);

            if (user is null)
            {
                return null;
            }


            return user;
        }

    }


}
