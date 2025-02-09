using System.ComponentModel.DataAnnotations;
using RestApiSample.src.Models;

namespace RestApiSample.src.Interfaces
{
    public class IUser
    {
        [EmailAddress(ErrorMessage = "The email address is not valid")]
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
    }

    public interface IUserService
    {

        public void initUserAdmin();

        public IFormatResponseService createUser(User user);

        public Task<IFormatResponseService> createUser(string email, IUser user);

        public Task<IFormatResponseService> createUser(IRegister user);

        public IFormatResponseService getUsers();

        public Task<IFormatResponseService> getUser(int id);

        public IFormatResponseService getUserByEmail(string email);

        public Task<IFormatResponseService?> updateUser(int id, User user);

        public Task<int?> deleteUser(int id);
    }
}