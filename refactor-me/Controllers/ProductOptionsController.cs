using System;
using System.Collections.Generic;
using System.Web.Http;
using refactor_me.Models;
using refactor_me.Queries;
using refactor_me.Services;

namespace refactor_me.Controllers
{
    [RoutePrefix("{productId}/options")]
    public class ProductOptionsController : ApiController
    {
		[Route]
		[HttpGet]
		public IEnumerable<ProductOption> GetOptions(Guid productId)
		{
            ProductOptionsQuery query = new ProductOptionsQuery();
            return query.GetAll(productId);
		}

		[Route("{id}")]
		[HttpGet]
		public IHttpActionResult GetOption(Guid productId, Guid id)
		{
            ProductOptionsQuery query = new ProductOptionsQuery();
            ProductOption option = query.GetOption(id);

			if (option == null)
			{
				return NotFound();
			}

			return Ok(option);
		}

		[Route]
		[HttpPost]
        public IHttpActionResult CreateOption(Guid productId, [FromBody] ProductOption option)
		{
			if (option == null)
			{
				return BadRequest();
			}

			new CreateProductOption(productId, option).Call();

			return Ok();
		}

		[Route("{id}")]
		[HttpPut]
		public IHttpActionResult UpdateOption(Guid id, [FromBody] ProductOption option)
		{
			if (option == null || option.Id != id)
			{
				return BadRequest();
			}

			ProductOptionsQuery query = new ProductOptionsQuery();
			ProductOption originalOption = query.GetOption(id);

			if (originalOption == null)
			{
				return NotFound();
			}

			new UpdateProductOption(id, option).Call();

			return Ok();
		}

		[Route("{id}")]
		[HttpDelete]
		public IHttpActionResult DeleteOption(Guid id)
		{
			ProductOptionsQuery query = new ProductOptionsQuery();
			ProductOption option = query.GetOption(id);

			if (option == null)
			{
				return NotFound();
			}

            new DeleteProductOption(option).Call();

			return Ok();
		}
    }
}
