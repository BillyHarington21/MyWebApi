using Domen.Entities;
using Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interface
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<Product> GetProductByIdAsync(int id);
        Task<Product> CreateProductAsync(ProductDTO productDto);
        Task<bool> UpdateProductAsync(int id, ProductDTO productDto);
        Task<bool> DeleteProductAsync(int id);
    }
}
