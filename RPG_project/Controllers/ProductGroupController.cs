using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RPG_project.DTOs.Product;
using RPG_project.Services.Charactor;

namespace RPG_project.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ProductGroupController : ControllerBase
    {
        private readonly IProductGroupService service;

        public ProductGroupController(IProductGroupService service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProductsGroup()
        {
            return Ok(await service.GetAllProductGroups());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductGroupById(int id)
        {
            return Ok(await service.GetProductGroupsById(id));
        }

        [HttpPost]
        public async Task<IActionResult> AddNewProduct(AddProductGroupDto input)
        {
            return Ok(await service.AddProductGroup(input));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditProductGroup(AddProductGroupDto input, int id)
        {
            return Ok(await service.EditProductGroup(input, id));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductGroup(int id)
        {
            return Ok(await service.DeleteProductGroup(id));
        }
    }
}