using System.Collections.Generic;
using dataaccess;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly Repository _respository;

        public ProductController(Repository respository)
        {
            _respository = respository;
        }

        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return _respository.GetProducts();
        }
    }
}
