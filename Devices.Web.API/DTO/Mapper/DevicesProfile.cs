using AutoMapper;
using Devices.Web.API.DTO;
using Devices.Web.API.Models.Entities;

namespace Devices.Web.API.ViewModels.Mapper
{
    public class DevicesProfile : Profile
    {
        public DevicesProfile()
        {
            CreateMap<Device, DeviceDTO>()
                .ForMember(d => d.DeviceTypeName, o => o.MapFrom(s => s.DeviceType.Name))
                .ForMember(d => d.DeviceStatusName, o => o.MapFrom(s => s.DeviceStatus.Name));
        }
    }
}