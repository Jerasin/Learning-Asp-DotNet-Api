using System.Net;
using JsonFlatFileDataStore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestApiSample.Models;
using RestApiSample.Services;

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
    public IActionResult Post([FromBody] User user)
    {
        // _users.InsertOne(user);
        _userService.createUser(user);

        return Created("", user);
    }

    [HttpGet]
    [Authorize]
    public Object Get()
    {
        var user = _userService.getUsers();

        // var test = new
        // {
        //     status = "444"
        // };

        // return test;

        return Ok(user);
    }

    [HttpGet("{id:int}")]
    [Authorize]
    public IActionResult GetById(int id)
    {
        // return _users.AsQueryable().FirstOrDefault(user => user.id == id);
        var user = _userService.getUser(id);

        if (user is null)
        {
            return NotFound(user);
        }

        return Ok(user);
    }

    [HttpPut("{id:int}")]
    [Authorize]
    public async Task<IActionResult> Put(int id, [FromBody] User user)
    {
        // var findUser = _users.AsQueryable().FirstOrDefault(user => user.id == id);

        // if (findUser == null) return null;

        // findUser = user;
        // await _users.UpdateOneAsync(user => user.id == id, findUser);

        // return findUser;


        await _userService.updateUser(id, user);

        return Ok(user);
    }

    [HttpDelete("{id:int}")]
    [Authorize]
    public async Task<IActionResult> delete(int id)
    {
        var deleteUser = await _userService.deleteUser(id);

        if (deleteUser is null)
        {
            return NotFound();
        }

        return Ok();
    }
}
