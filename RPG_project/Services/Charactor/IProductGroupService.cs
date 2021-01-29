using System.Collections.Generic;
using System.Threading.Tasks;
using RPG_project.DTOs.Product;
using RPG_project.Models;

namespace RPG_project.Services.Charactor
{
    public interface IProductGroupService
    {
        Task<ServiceResponse<List<GetProductGroupDto>>> GetAllProductGroups();
        Task<ServiceResponse<GetProductGroupDto>> GetProductGroupsById(int id);
        Task<ServiceResponse<GetProductGroupDto>> AddProductGroup(AddProductGroupDto input);
        Task<ServiceResponse<GetProductGroupDto>> EditProductGroup(AddProductGroupDto input, int id);
        Task<ServiceResponse<GetProductGroupDto>> DeleteProductGroup(int id);

    }
}