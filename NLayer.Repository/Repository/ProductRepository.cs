﻿using Microsoft.EntityFrameworkCore;
using NLayer.Core.Models;
using NLayer.Core.Repositories;

namespace NLayer.Repository.Repository
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context)
        {

        }

        public async Task<List<Product>> GetProductsWithCategory()
        {
            //eager loading
            return await _context.Products.Include(x => x.Category).ToListAsync();
        }
    }
}
