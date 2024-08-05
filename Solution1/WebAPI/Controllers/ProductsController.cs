using Business;
using DataAccess;
using Entities;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace WebAPI
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result=_productService.GetAll();
            if(result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            var result = _productService.GetByProductId(id);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpPost("Add")]
        public IActionResult Add(Product product)
        {
            var result=_productService.Add(product);
            if(result.Success)
                return Ok(result);
            return BadRequest(result);
        }
    }
}
