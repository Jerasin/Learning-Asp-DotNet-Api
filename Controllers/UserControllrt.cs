using JsonFlatFileDataStore;
using Microsoft.AspNetCore.Mvc;

namespace RestApiSample.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{

    private readonly ILogger<UserController> _logger;
    private readonly IDocumentCollection<User> _users;

    public UserController(ILogger<UserController> logger)
    {
        _logger = logger;
        var store = new DataStore("db.json");
        _users = store.GetCollection<User>();
    }

    [HttpPost]
    public void Post([FromBody] User user)
    {
        _users.InsertOne(user);
    }

    [HttpGet]
    public IEnumerable<User> Get()
    {
        return _users.AsQueryable().ToList();
    }

    [HttpGet("{id:int}")]
    public User GetById(int id)
    {
        return _users.AsQueryable().FirstOrDefault(user => user.id == id);
    }

    [HttpPut("{id:int}")]
    async public Task<User> UpdateUserById(int id, [FromBody] User user)
    {
        var findUser = _users.AsQueryable().FirstOrDefault(user => user.id == id);

        if (findUser == null) return null;

        findUser = user;
        await _users.UpdateOneAsync(user => user.id == id, findUser);

        return findUser;
    }
}
