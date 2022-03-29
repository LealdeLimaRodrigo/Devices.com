using Devices.Web.API.Models.Context;
using Devices.Web.API.Models.Entities;
using Devices.Web.API.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Devices.Web.API.Repositories
{
    public class DeviceRepository : RepositoryBase<Device>
    {
        private readonly DevicesDBContext _dbContext;
        public DeviceRepository(DevicesDBContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Device>> FindAllAsyncIncludeDevice()
        {
            return await _dbContext.Set<Device>().Include(x => x.DeviceType).Include(x => x.DeviceStatus).Include(x => x.DeviceUsages).ToListAsync();
        }

        public async Task<Device> FindAsyncIncludeDeviceById(int id)
        {
            return await _dbContext.Set<Device>().Include(x => x.DeviceType).Include(x => x.DeviceStatus).Include(x => x.DeviceUsages).SingleOrDefaultAsync(x => x.DeviceId == id);
        }

    }
}