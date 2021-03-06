using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using testAPI.Model;

namespace testAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdController : ControllerBase
    {
        private readonly ProductRepository productRepository;

        public ProdController()
        {
            productRepository = new ProductRepository();
        }

        [HttpGet]
        [Route("getall")]
        public IEnumerable<Product>Get()
        {
            return productRepository.GetAll();
        }

        [HttpGet("{id}")]
        public Product Get(int id)
        {
            return productRepository.GetById(id);
        }

        [HttpPost]
        public void Post([FromBody]Product prod)
        {
            if (ModelState.IsValid)
                productRepository.Add(prod);
        }

        [HttpPut]
        public void Put([FromBody]Product prod)
        {
            //prod.ID = id;
            if (ModelState.IsValid)
                productRepository.Update(prod);
        }

        [HttpPost]
        [Route("delete")]
        public void Delete([FromBody] Product prod)
        {
            productRepository.Delete(prod.ID);
        }
    }
}
