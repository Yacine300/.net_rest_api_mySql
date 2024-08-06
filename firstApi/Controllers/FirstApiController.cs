using firstApi.CommenLayer.Model;
using firstApi.ServiceLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace firstApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FirstApiController : ControllerBase
    {
        public readonly IApiSL _apiSL;

        public FirstApiController(IApiSL apiSL)
        {
            _apiSL = apiSL;
        }

        [HttpPost("AddInformations")]
        public async Task<IActionResult> AddInformation(AddUserRequest request)
        {
            AddUserResponse response = new AddUserResponse();
            try
            {
                response = await _apiSL.AddInformation(request);

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
                

            }
            return Ok(response) ;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            LoginResponse response = new LoginResponse();
            try
            {
                response = await _apiSL.Login(request);

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;


            }
            return Ok(response);
        }
    }
}
