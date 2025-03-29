﻿using SkyMirror.Entities;

namespace SkyMirror.DataAccess.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllAsync(); 
        Task<Product?> GetByIdAsync(int id);
        Task<int> AddAsync(Product product);
        Task UpdateAsync(Product product);
        Task DeleteAsync(int id);
    }
}
