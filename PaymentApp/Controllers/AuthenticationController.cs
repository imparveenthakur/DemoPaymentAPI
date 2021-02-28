using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaymentApp.API.Helpers;
using PaymentApp.Service.Interface;
using PaymentApp.ViewModel.Authentication;

namespace PaymentApp.API.Controllers
{
    [Authorize, Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IResponseFactory _responseFactory;

        public AuthenticationController(IUserService userService, IResponseFactory responseFactory)
        {
            _userService = userService;
            _responseFactory = responseFactory;
        }
        [AllowAnonymous, HttpPost("GenerateToken")]
        public async Task<IActionResult> GenerateAccessToken([FromBody] LoginVM loginVM)
        {
            try
            {
                TokenVM tokenVM = await _userService.Authenticate(loginVM);

                var response = _responseFactory.CreateResponse(loginVM);
                return Ok(response);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
    }
}
