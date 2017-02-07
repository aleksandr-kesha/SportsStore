using System.Collections.Generic;

namespace SportsStore.Models.Repository
{
    public class Repository
    {
        private readonly EfDbContext _context = new EfDbContext();

        public IEnumerable<Product> Products => _context.Products;
    }
}