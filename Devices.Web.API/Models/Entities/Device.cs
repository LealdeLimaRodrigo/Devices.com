using System;
using System.Collections.Generic;

namespace Devices.Web.API.Models.Entities
{
    public partial class Device
    {
        public Device()
        {
            DeviceUsages = new HashSet<DeviceUsage>();
        }

        public int DeviceId { get; set; }
        public int DeviceTypeId { get; set; }
        public int DeviceStatusId { get; set; }
        public string Name { get; set; } = null!;
        public short Temperature { get; set; }

        public virtual DeviceStatus DeviceStatus { get; set; } = null!;
        public virtual DeviceType DeviceType { get; set; } = null!;
        public virtual ICollection<DeviceUsage> DeviceUsages { get; set; }
    }
}
