using System.Net;
using JsonFlatFileDataStore;
using Microsoft.AspNetCore.Mvc;

namespace RestApiSample.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{

    private readonly ILogger<UserController> _logger;
    private readonly IDocumentCollection<User> _users;

    private readonly ApiDbContext _dbContext;

    public UserController(ILogger<UserController> logger, ApiDbContext dbContext)
    {
        _logger = logger;
        var store = new DataStore("db.json");
        _users = store.GetCollection<User>();
        _dbContext = dbContext;
    }

    [HttpPost]
    public HttpStatusCode Post([FromBody] User user)
    {
        // _users.InsertOne(user);
        _dbContext.Add(user);
        _dbContext.SaveChanges();

        return HttpStatusCode.Created;
    }

    [HttpGet]
    public IEnumerable<User> Get()
    {
        return _dbContext.User.ToList();
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
