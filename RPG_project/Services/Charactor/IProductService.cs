
using System.Collections.Generic;
using System.Threading.Tasks;
using RPG_project.DTOs.Product;
using RPG_project.Models;

namespace RPG_project.Services.Charactor
{
    public interface IProductService
    {
        Task<ServiceResponse<List<GetProductDto>>> GetAllProducts();
        Task<ServiceResponse<GetProductDto>> GetProductsById(int id);
        Task<ServiceResponse<GetProductDto>> AddProduct(AddProductDto input);
        Task<ServiceResponse<GetProductDto>> EditProduct(AddProductDto input, int id);
        Task<ServiceResponse<GetProductDto>> DeleteProduct(int id);
    }
}
