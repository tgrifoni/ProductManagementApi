using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PM.Api.Domain.Queries.v1.Authentication;
using System;
using System.Net;
using System.Threading.Tasks;

namespace PM.Api.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class AuthenticationController : ControllerBase
    {
        private readonly ILogger<AuthenticationController> _logger;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public AuthenticationController(ILogger<AuthenticationController> logger, IMapper mapper, IMediator mediator)
        {
            _logger = logger;
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Authenticate(string username, string password)
        {
            try
            {
                var response = await _mediator.Send(new AuthenticationQuery(username, password));

                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.ToString());
            }
        }
    }
}