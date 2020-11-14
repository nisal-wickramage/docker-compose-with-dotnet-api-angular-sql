using System.Collections.Generic;
using System.Linq;

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
            return _dbContext.Products.ToList();
        }
            
    }
}
