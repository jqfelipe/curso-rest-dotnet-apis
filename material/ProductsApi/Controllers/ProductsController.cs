using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProductsApi.Models;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProductsApi.Controllers
{
  [Route("api/v1/[controller]")]
  [ApiController]
  public class ProductsController : ControllerBase
  {

    private readonly ILogger<ProductsController> _logger;
    //private readonly AdventureWorksDbContext _context;
    private readonly ProductRepository _productRepository;

    public ProductsController(ILogger<ProductsController> logger
      , ProductRepository productRepository
        //, AdventureWorksDbContext context
        )
    {
      _logger = logger;
      //_context = context; 
      _logger.LogInformation("Constructor products");
      _productRepository = productRepository;
    }

    // GET: api/<ProductsController>
    [HttpGet]
    public IEnumerable<Product> Get()
    {
      return _productRepository.Get();
    }

    // GET api/<ProductsController>/5
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
      var result = _productRepository.Get(id);
      if (result == null)
        return NotFound();

      return Ok(result);
    }

    // POST api/<ProductsController>
    [HttpPost]
    public IActionResult Post([FromBody] Product value)
    {
      Product result = _productRepository.Add(value);
      return CreatedAtAction(nameof(GetById), new { Id = result.ProductId }, value);
    }

    // PUT api/<ProductsController>/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/<ProductsController>/5
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
      var result = _productRepository.Get(id);
      if (result == null)
        return NotFound();

      _productRepository.Delete(id);
      return new ObjectResult(new object()) { StatusCode = (int)HttpStatusCode.NotImplemented };
    }
  }
}
