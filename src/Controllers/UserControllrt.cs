using System.Net;
using JsonFlatFileDataStore;
using Microsoft.AspNetCore.Mvc;
using Models.User;
using Services.UserService;

namespace RestApiSample.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{

    private readonly ILogger<UserController> _logger;
    private readonly IDocumentCollection<User> _users;
    private readonly UserService _userService;


    public UserController(ILogger<UserController> logger, UserService userService)
    {
        _logger = logger;
        var store = new DataStore("db.json");
        _users = store.GetCollection<User>();
        _userService = userService;


    }

    [HttpPost]
    public HttpStatusCode Post([FromBody] User user)
    {
        // _users.InsertOne(user);
        _userService.createUser(user);

        return HttpStatusCode.Created;
    }

    [HttpGet]
    public IActionResult Get()
    {
        var user = _userService.getUsers();

        return Ok(user);
    }

    [HttpGet("{id:int}")]
    public User GetById(int id)
    {
        // return _users.AsQueryable().FirstOrDefault(user => user.id == id);
        return _userService.getUser(id);

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
