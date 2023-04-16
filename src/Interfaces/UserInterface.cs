using RestApiSample.Models;

namespace RestApiSample.Interfaces
{
    interface IUserService
    {

        public void initUserAdmin();

        public int createUser(User user);

        public List<User> getUsers();

        public User? getUser(int id);

        public User? getUserByEmail(string email);

        public Task<int?> updateUser(int id, User user);

        public Task<int?> deleteUser(int id);
    }
}