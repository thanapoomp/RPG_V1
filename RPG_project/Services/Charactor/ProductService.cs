using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RPG_project.Data;
using RPG_project.DTOs.Product;
using RPG_project.Models;

namespace RPG_project.Services.Charactor
{
    public class ProductService : IProductService
    {
        private readonly AppDBContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ILogger<ProductService> _log;

        public ProductService(AppDBContext dbContext, IMapper mapper, ILogger<ProductService> log)
        {
            this._dbContext = dbContext;
            this._mapper = mapper;
            this._log = log;
        }

        public async Task<ServiceResponse<GetProductDto>> AddProduct(AddProductDto input)
        {
            try
            {
                var productGroup = await _dbContext.ProductGroups.Where(x => x.Id == input.ProductGroupId).FirstOrDefaultAsync();

                if (productGroup is null)
                {
                    return ResponseResult.Failure<GetProductDto>("Product group not found");
                }

                var product = new Product();
                product.Name = input.Name;
                product.Price = input.Price;
                product.StockCount = input.StockCount;
                product.ProductGroupId = input.ProductGroupId;

                await _dbContext.Products.AddAsync(product);
                await _dbContext.SaveChangesAsync();

                var dto = _mapper.Map<GetProductDto>(product);
                return ResponseResult.Success<GetProductDto>(dto);
            }
            catch (System.Exception ex)
            {
                _log.LogError(ex.Message);
                return ResponseResult.Failure<GetProductDto>(ex.Message);
            }
        }

        public async Task<ServiceResponse<GetProductDto>> DeleteProduct(int id)
        {
            try
            {
                var product = await GetProductById(id);
                if (product is null)
                {
                    return ResponseResult.Failure<GetProductDto>("Product not found");
                }

                _dbContext.Products.Remove(product);
                await _dbContext.SaveChangesAsync();

                var dto = new GetProductDto();

                return ResponseResult.Success<GetProductDto>(dto);
            }
            catch (System.Exception ex)
            {
                _log.LogError(ex.Message);
                return ResponseResult.Failure<GetProductDto>(ex.Message);
            }
        }

        public async Task<ServiceResponse<GetProductDto>> EditProduct(AddProductDto input, int id)
        {
             try
            {
                var product = await GetProductById(id);
                if (product is null)
                {
                    return ResponseResult.Failure<GetProductDto>("Product not found");
                }

                product.Name = input.Name;
                product.Price = input.Price;
                product.StockCount = input.StockCount;
                product.ProductGroupId = input.ProductGroupId;
                
                _dbContext.Update(product);
                await _dbContext.SaveChangesAsync();

                var dto = _mapper.Map<GetProductDto>(product);

                return ResponseResult.Success<GetProductDto>(dto);
            }
            catch (System.Exception ex)
            {
                _log.LogError(ex.Message);
                return ResponseResult.Failure<GetProductDto>(ex.Message);
            }
        }

        public async Task<ServiceResponse<List<GetProductDto>>> GetAllProducts()
        {
            var products = await _dbContext.Products
            .Include(x => x.ProductGroup)
            .ToListAsync();
            
            var dto = _mapper.Map<List<GetProductDto>>(products);
            return ResponseResult.Success<List<GetProductDto>>(dto);
        }

        public async Task<ServiceResponse<GetProductDto>> GetProductsById(int id)
        {
            try
            {
                var product = await GetProductById(id);
                if (product is null)
                {
                    return ResponseResult.Failure<GetProductDto>("Product not found");
                }

                var dto = _mapper.Map<GetProductDto>(product);

                return ResponseResult.Success<GetProductDto>(dto);
            }
            catch (System.Exception ex)
            {
                _log.LogError(ex.Message);
                return ResponseResult.Failure<GetProductDto>(ex.Message);
            }
        }

        private async Task<Product> GetProductById(int id)
        {
            return await _dbContext.Products
            .Include(x => x.ProductGroup)
            .Where(x => x.Id == id)
            .FirstOrDefaultAsync();
        }

    }
}