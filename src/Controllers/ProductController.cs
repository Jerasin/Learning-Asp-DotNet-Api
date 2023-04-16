using System.Net;
using JsonFlatFileDataStore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestApiSample.Models;
using RestApiSample.Services;

namespace RestApiSample.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{

    private readonly ILogger<UserController> _logger;
    private readonly ProductService _productService;


    public ProductController(ILogger<UserController> logger, ProductService productService)
    {
        _logger = logger;
        _productService = productService;
    }

    [HttpPost]
    [Authorize]
    public IActionResult Post([FromBody] Product product)
    {
        // _users.InsertOne(user);
        _productService.createProduct(product);

        return Created("", product);
    }

    [HttpGet]
    [Authorize]
    public Object Get()
    {
        var products = _productService.getProducts();

        // var test = new
        // {
        //     status = "444"
        // };

        // return test;

        return Ok(products);
    }

    [HttpGet("{id:int}")]
    [Authorize]
    public IActionResult GetById(int id)
    {
        var product = _productService.getProduct(id);

        if (product is null)
        {
            return NotFound(product);
        }

        return Ok(product);
    }

    [HttpPut("{id:int}")]
    [Authorize]
    public async Task<IActionResult> Put(int id, [FromBody] Product product)
    {
        // var findUser = _users.AsQueryable().FirstOrDefault(user => user.id == id);

        // if (findUser == null) return null;

        // findUser = user;
        // await _users.UpdateOneAsync(user => user.id == id, findUser);

        // return findUser;


        await _productService.updateProduct(id, product);

        return Ok(product);
    }

    [HttpDelete("{id:int}")]
    [Authorize]
    public async Task<IActionResult> delete(int id)
    {
        var deleteUser = await _productService.deleteProduct(id);

        if (deleteUser is null)
        {
            return NotFound();
        }

        return Ok();
    }
}
