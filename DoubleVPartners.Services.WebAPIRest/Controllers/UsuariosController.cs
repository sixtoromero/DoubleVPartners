using DoubleVPartners.Application.DTO;
using DoubleVPartners.Application.Interface;
using DoubleVPartners.Services.WebAPIRest.Helpers;
using DoubleVPartners.Transversal.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using DoubleVPartners.Application.DTO.Request;

namespace DoubleVPartners.Services.WebAPIRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuariosApplication _Application;
        private readonly AppSettings _appSettings;
        private readonly IWebHostEnvironment env;
        private IConfiguration _config;
        
        public UsuariosController(IUsuariosApplication application, IOptions<AppSettings> appSettings, IWebHostEnvironment env, IConfiguration config)
        {
            _Application = application;
            _appSettings = appSettings.Value;
            this.env = env;
            _config = config;
        }

        [HttpGet("GetAllAsync")]
        public async Task<IActionResult> GetAllAsync()
        {
            Response<IEnumerable<UsuarioDTO>> response = new Response<IEnumerable<UsuarioDTO>>();

            try
            {
                response = await _Application.GetAllAsync();
                if (response.IsSuccess)
                {
                    return Ok(response);
                }
                else
                {
                    return BadRequest(response);
                }
            }
            catch (Exception ex)
            {
                response.Data = null;
                response.IsSuccess = false;
                response.Message = ex.Message;

                return BadRequest(response);
            }
        }

        [HttpGet("GetAsync")]
        public async Task<IActionResult> GetAsync(int id)
        {
            Response<UsuarioDTO> response = new Response<UsuarioDTO>();

            try
            {
                response = await _Application.GetAsync(id);
                if (response.IsSuccess)
                {
                    return Ok(response);
                }
                else
                {
                    return BadRequest(response);
                }
            }
            catch (Exception ex)
            {
                response.Data = null;
                response.IsSuccess = false;
                response.Message = ex.Message;

                return BadRequest(response);
            }
        }

        [HttpPost("InsertAsync")]
        public async Task<IActionResult> InsertAsync(UsuarioDTO modelDto)
        {
            Response<bool> response = new Response<bool>();

            try
            {
                if (modelDto == null)
                    return BadRequest();

                response = await _Application.InsertAsync(modelDto);
                if (response.IsSuccess)
                {
                    return Ok(response);
                }
                else
                {
                    return BadRequest(response);
                }
            }
            catch (Exception ex)
            {
                response.Data = false;
                response.IsSuccess = false;
                response.Message = ex.Message;

                return BadRequest(response);
            }
        }

        [HttpPut("UpdateAsync")]
        public async Task<IActionResult> UpdateAsync(UsuarioDTO modelDto)
        {
            Response<bool> response = new Response<bool>();

            try
            {
                if (modelDto == null)
                    return BadRequest();

                response = await _Application.UpdateAsync(modelDto);
                if (response.IsSuccess)
                {
                    return Ok(response);
                }
                else
                {
                    return BadRequest(response);
                }
            }
            catch (Exception ex)
            {
                response.Data = false;
                response.IsSuccess = false;
                response.Message = ex.Message;

                return BadRequest(response);
            }
        }

        [HttpPost("DelAsync")]
        public async Task<IActionResult> DelAsync(int Id)
        {
            Response<bool> response = new Response<bool>();
            try
            {
                response = await _Application.DeleteAsync(Id);
                if (response.IsSuccess)
                {
                    return Ok(response);
                }
                else
                {
                    return BadRequest(response);
                }
            }
            catch (Exception ex)
            {
                response.Data = false;
                response.IsSuccess = false;
                response.Message = ex.Message;

                return BadRequest(response);
            }
        }

        [HttpPost("Autenticar")]
        public async Task<IActionResult> Autenticar(AuthDTO request)
        {
            Response<UsuarioDTO?> response = new Response<UsuarioDTO?>();

            try
            {
                response = await _Application.Autenticar(request.NombreUsuario, request.Clave);
                if (response.IsSuccess)
                {                    
                    response.Data.Token = General.BuildToken(response.Data, _appSettings);
                    return Ok(response);
                }
                else
                {
                    return BadRequest(response);
                }
            }
            catch (Exception ex)
            {
                response.Data = null;
                response.IsSuccess = false;
                response.Message = ex.Message;

                return BadRequest(response);
            }
        }
    }
}
