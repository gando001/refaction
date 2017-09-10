using System;
using System.Collections.Generic;
using System.Web.Http;
using refactor_me.Models;
using refactor_me.Queries;
using refactor_me.Services;

namespace refactor_me.Controllers
{
    [RoutePrefix("products")]
    public class ProductsController : ApiController
    {
        [Route]
        [HttpGet]
        public IEnumerable<Product> GetAll()
        {
            ProductsQuery query = new ProductsQuery();
            return query.GetAll();
        }

        [Route]
        [HttpGet]
        public IEnumerable<Product> SearchByName(string name)
        {
			ProductsQuery query = new ProductsQuery();
			return query.GetProduct(name);
        }

        [Route("{id}")]
        [HttpGet]
        public IHttpActionResult GetProduct(Guid id)
        {
			ProductsQuery query = new ProductsQuery();
			Product product = query.GetProduct(id);

            if (product == null)
			{
				return NotFound();
			}

            return Ok(product);
        }

        [Route]
        [HttpPost]
        public IHttpActionResult Create([FromBody] Product product)
        {
			if (product == null)
			{
                return BadRequest();
			}

            new CreateProduct(product).Call();

            return Ok();
        }

        [Route("{id}")]
        [HttpPut]
        public IHttpActionResult Update(Guid id, [FromBody] Product product)
        {
            if (product == null || product.Id != id)
			{
				return BadRequest();
			}

			ProductsQuery query = new ProductsQuery();
			Product originalProduct = query.GetProduct(id);

			if (originalProduct == null)
			{
				return NotFound();
			}

            new UpdateProduct(id, product).Call();

            return Ok();
        }

        [Route("{id}")]
        [HttpDelete]
        public IHttpActionResult Delete(Guid id)
        {
			ProductsQuery query = new ProductsQuery();
			Product product = query.GetProduct(id);

			if (product == null)
			{
				return NotFound();
			}

            new DeleteProduct(product).Call();
			
			return Ok();
        }
    }
}
