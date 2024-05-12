using AutoMapper;
using DoubleVPartners.Application.DTO;
using DoubleVPartners.Application.Interface;
using DoubleVPartners.Domain.Entity;
using DoubleVPartners.Domain.Interface;
using DoubleVPartners.Transversal.Common;

namespace DoubleVPartners.Application.Main
{
    public class UsuariosApplication : IUsuariosApplication
    {
        private readonly IPersonasDomain _Domain;
        private readonly IMapper _mapper;
        private readonly IAppLogger<UsuariosApplication> _logger;

        public UsuariosApplication(IPersonasDomain domain, IMapper mapper, IAppLogger<UsuariosApplication> logger)
        {
            _Domain = domain;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Response<bool>> InsertAsync(UsuarioDTO modelDto)
        {
            var response = new Response<bool>();
            try
            {
                var resp = _mapper.Map<Persona>(modelDto);
                response.Data = await _Domain.InsertAsync(resp);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Registro Exitoso!";
                }
            }
            catch (Exception ex)
            {
                response.Data = false;
                response.IsSuccess = false;
                response.Message = ex.Message;

                _logger.LogError(ex.Message);
            }

            return response;
        }

        public async Task<Response<bool>> UpdateAsync(UsuarioDTO modelDto)
        {
            var response = new Response<bool>();
            try
            {
                var resp = _mapper.Map<Persona>(modelDto);
                response.Data = await _Domain.UpdateAsync(resp);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Registro Exitoso!";
                }
            }
            catch (Exception ex)
            {
                response.Data = false;
                response.IsSuccess = false;
                response.Message = ex.Message;

                _logger.LogError(ex.Message);
            }

            return response;
        }

        public async Task<Response<bool>> DeleteAsync(int id)
        {
            var response = new Response<bool>();
            try
            {
                response.Data = await _Domain.DeleteAsync(id);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Eliminación Exitosa!";
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                _logger.LogError(ex.Message);
            }

            return response;
        }

        public async Task<Response<UsuarioDTO>> GetAsync(int id)
        {
            var response = new Response<UsuarioDTO>();
            try
            {
                var result = await _Domain.GetAsync(id);

                response.Data = _mapper.Map<UsuarioDTO>(result);
                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Consulta Exitosa!";
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                _logger.LogError(ex.Message);
            }

            return response;
        }

        public async Task<Response<IEnumerable<UsuarioDTO>>> GetAllAsync()
        {
            var response = new Response<IEnumerable<UsuarioDTO>>();
            try
            {
                var resp = await _Domain.GetAllAsync();

                response.Data = _mapper.Map<IEnumerable<UsuarioDTO>>(resp);
                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = string.Empty;
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                _logger.LogError(ex.Message);
            }

            return response;
        }
    }
}
