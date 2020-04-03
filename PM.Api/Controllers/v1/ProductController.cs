using AutoMapper;
using PM.Api.Domain.Commands.v1.Product;
using PM.Api.Domain.Queries.v1.Product;
using PM.Api.Models.Product;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace PM.Api.Controllers.v1
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public ProductController(ILogger<ProductController> logger, IMapper mapper, IMediator mediator)
        {
            _logger = logger;
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var response = await _mediator.Send(new GetProductsQuery());
                var products = _mapper.Map<IEnumerable<GetProductsDTO>>(response.Products);

                return Ok(products);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode((int) HttpStatusCode.InternalServerError, ex.ToString());
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            try
            {
                var response = await _mediator.Send(new GetProductQuery(id));

                if (response.Product == null)
                    return NotFound();

                var product = _mapper.Map<ProductDTO>(response.Product);
                return Ok(product);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.ToString());
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] SaveProductRequest request)
        {
            try
            {
                var command = _mapper.Map<AddProductCommand>(request);
                var id = await _mediator.Send(command);

                return Created($"/product/{id}", request.Product);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.ToString());
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, [FromBody] SaveProductRequest request)
        {
            try
            {
                if (id != request.Product.Id)
                    return BadRequest();

                var command = _mapper.Map<UpdateProductCommand>(request);
                await _mediator.Send(command);

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.ToString());
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            try
            {
                var command = new DeleteProductCommand(id);
                await _mediator.Send(command);

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.ToString());
            }
        }
    }
}
