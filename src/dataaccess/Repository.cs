using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace dataaccess
{
    public class Repository
    {
        private readonly ProductDbContext _dbContext;
        public Repository(ProductDbContext dbContext)
        {
            _dbContext = dbContext;            
        }
        public IList<Product> GetProducts() 
        { 
            _dbContext.Database.Migrate();
            return _dbContext.Products.ToList();
        }
            
    }
}
