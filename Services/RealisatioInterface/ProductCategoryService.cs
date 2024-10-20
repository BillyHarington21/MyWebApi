using Domen.Context;
using Domen.Entities;
using Microsoft.EntityFrameworkCore;
using Services.DTO;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.RealisatioInterface
{
    public class ProductCategoryService : IProductCategoryService
    {
        private readonly AppDbContext _context;

        public ProductCategoryService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProductCategory>> GetAllCategoriesAsync()
        {
            return await _context.ProductCategories.ToListAsync();
        }

        public async Task<ProductCategory> GetCategoryByIdAsync(int id)
        {
            var category = await _context.ProductCategories.FindAsync(id);
            if (category == null)
            {
                return null;
            }
            return category;
        }

        public async Task<ProductCategory> CreateCategoryAsync(ProductCategoryDTO categoryDto)
        {
            var newCategory = new ProductCategory
            {
                Name = categoryDto.Name,
                Description = categoryDto.Description
            };

            _context.ProductCategories.Add(newCategory);
            await _context.SaveChangesAsync();
            return newCategory;
        }

        public async Task<bool> UpdateCategoryAsync(int id, ProductCategoryDTO categoryDto)
        {
            var existingCategory = await _context.ProductCategories.FindAsync(id);
            if (existingCategory == null)
            {
                return false;
            }

            existingCategory.Name = categoryDto.Name;
            existingCategory.Description = categoryDto.Description;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteCategoryAsync(int id)
        {
            var category = await _context.ProductCategories.FindAsync(id);
            if (category == null)
            {
                return false;
            }

            _context.ProductCategories.Remove(category);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
