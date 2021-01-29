using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RPG_project.DTOs.Product;
using RPG_project.Services.Charactor;

namespace RPG_project.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService service;

        public ProductController(IProductService service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            return Ok(await service.GetAllProducts());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            return Ok(await service.GetProductsById(id));
        }

        [HttpPost]
        public async Task<IActionResult> AddNewProduct(AddProductDto input)
        {
            return Ok(await service.AddProduct(input));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditProduct(AddProductDto input, int id)
        {
            return Ok(await service.EditProduct(input, id));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            return Ok(await service.DeleteProduct(id));
        }
    }
}