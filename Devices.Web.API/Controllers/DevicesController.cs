using AutoMapper;
using Devices.Web.API.DTO;
using Devices.Web.API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Devices.Web.API.Controllers
{
    [Route("devices")]
    [ApiController]
    public class DevicesController : Controller
    {
        private readonly IMapper _mapper;
        private DeviceRepository _repositorio;

        public DevicesController(DeviceRepository repositorio, IMapper mapper)
        {
            _repositorio = repositorio;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult> GetDevices()
        {
            var list = await _repositorio.FindAllAsyncIncludeDevice();
            var listMap = _mapper.Map<IEnumerable<DeviceDTO>>(list);
            return Ok(listMap);            
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetDeviceByID(int id)
        {
            var obj = await _repositorio.FindAsyncIncludeDeviceById(id);
            if (obj != null)
            {
                var objMap = _mapper.Map<DeviceDTO>(obj);
                return Ok(objMap);
            }
            else
                return NotFound();
        }

    }
}
