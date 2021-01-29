using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RPG_project.Data;
using RPG_project.DTOs.Charactor;
using RPG_project.DTOs.Product;
using RPG_project.Models;

namespace RPG_project.Services.Charactor
{
    public class ProductGroupService : IProductGroupService
    {
        private readonly AppDBContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ILogger _log;

        public ProductGroupService(AppDBContext dbContext, IMapper mapper, ILogger<ProductGroupService> log)
        {
            this._log = log;
            this._mapper = mapper;
            this._dbContext = dbContext;

        }

        public async Task<ServiceResponse<GetProductGroupDto>> AddProductGroup(AddProductGroupDto input)
        {
            try
            {
                var productGroup = new ProductGroup();
                productGroup.Name = input.Name;

                await _dbContext.ProductGroups.AddAsync(productGroup);
                await _dbContext.SaveChangesAsync();

                var dto = _mapper.Map<GetProductGroupDto>(productGroup);
                return ResponseResult.Success<GetProductGroupDto>(dto);
            }
            catch (System.Exception ex)
            {
                _log.LogError(ex.Message);
                return ResponseResult.Failure<GetProductGroupDto>(ex.Message);
            }
        }

        public async Task<ServiceResponse<GetProductGroupDto>> DeleteProductGroup(int id)
        {
            try
            {
                var productGroup = await GetProductGroupById(id);
                if (productGroup is null)
                {
                    return ResponseResult.Failure<GetProductGroupDto>("Product group not found");
                }

                _dbContext.ProductGroups.Remove(productGroup);
                await _dbContext.SaveChangesAsync();

                var dto = new GetProductGroupDto();

                return ResponseResult.Success<GetProductGroupDto>(dto);
            }
            catch (System.Exception ex)
            {
                _log.LogError(ex.Message);
                return ResponseResult.Failure<GetProductGroupDto>(ex.Message);
            }
        }

        public async Task<ServiceResponse<GetProductGroupDto>> EditProductGroup(AddProductGroupDto input, int id)
        {
            try
            {
                var productGroup = await GetProductGroupById(id);
                if (productGroup is null)
                {
                    return ResponseResult.Failure<GetProductGroupDto>("Product group not found");
                }

                productGroup.Name = input.Name;

                _dbContext.Update(productGroup);
                await _dbContext.SaveChangesAsync();

                var dto = _mapper.Map<GetProductGroupDto>(productGroup);

                return ResponseResult.Success<GetProductGroupDto>(dto);
            }
            catch (System.Exception ex)
            {
                _log.LogError(ex.Message);
                return ResponseResult.Failure<GetProductGroupDto>(ex.Message);
            }
        }

        public async Task<ServiceResponse<List<GetProductGroupDto>>> GetAllProductGroups()
        {
            var productGroups = await _dbContext.ProductGroups.Include(x => x.Products).ToListAsync();
            var dto = _mapper.Map<List<GetProductGroupDto>>(productGroups);
            return ResponseResult.Success<List<GetProductGroupDto>>(dto);
        }

        public async Task<ServiceResponse<GetProductGroupDto>> GetProductGroupsById(int id)
        {
            try
            {
                var productGroup = await GetProductGroupById(id);
                if (productGroup is null)
                {
                    return ResponseResult.Failure<GetProductGroupDto>("Product group not found");
                }

                var dto = _mapper.Map<GetProductGroupDto>(productGroup);

                return ResponseResult.Success<GetProductGroupDto>(dto);
            }
            catch (System.Exception ex)
            {
                _log.LogError(ex.Message);
                return ResponseResult.Failure<GetProductGroupDto>(ex.Message);
            }
        }

        private async Task<ProductGroup> GetProductGroupById(int id)
        {
            return await _dbContext.ProductGroups.Where(x => x.Id == id).Include(x => x.Products).FirstOrDefaultAsync();
        }

    }
}