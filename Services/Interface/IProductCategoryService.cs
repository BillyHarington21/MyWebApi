using Domen.Entities;
using Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interface
{
    public interface IProductCategoryService
    {
        Task<IEnumerable<ProductCategory>> GetAllCategoriesAsync();
        Task<ProductCategory> GetCategoryByIdAsync(int id);
        Task<ProductCategory> CreateCategoryAsync(ProductCategoryDTO categoryDto);
        Task<bool> UpdateCategoryAsync(int id, ProductCategoryDTO categoryDto);
        Task<bool> DeleteCategoryAsync(int id);
    }
}
