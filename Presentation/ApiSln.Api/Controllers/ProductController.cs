using ApiSln.Application.Features.Products.Commands.CreateProduct;
using ApiSln.Application.Features.Products.Commands.DeleteProduct;
using ApiSln.Application.Features.Products.Commands.UpdateProduct;
using ApiSln.Application.Features.Products.Queries.GetAllProducts;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiSln.Api.Controllers
{
	[Route("api/[controller]/[action]")]
	[ApiController]
	public class ProductController : ControllerBase
	{
		private readonly IMediator mediator;

		public ProductController(IMediator mediator)
		{
			this.mediator = mediator;
		}
		[HttpGet]
		[Authorize]
		public async Task<IActionResult> GetAllProducts()
		{
			var response = await mediator.Send(new GetAllProductsQueryRequest());
			return Ok(response);
		}
		[HttpPost]
		public async Task<IActionResult> CreateProduct(CreateProductCommandRequest createProductCommandRequest)
		{
			await mediator.Send(createProductCommandRequest);
			return Ok();
		}
		[HttpPut]
		public async Task<IActionResult> UpdateProduct(UpdateProductCommandRequest updateProductCommandRequest)
		{
			await mediator.Send(updateProductCommandRequest);
			return Ok();
		}
		[HttpDelete]
		public async Task<IActionResult> DeleteProduct(DeleteProductCommandRequest deleteProductCommandRequest)
		{
			await mediator.Send(deleteProductCommandRequest);
			return Ok();
		}
	}
}
