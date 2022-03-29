using System;
using System.Collections.Generic;

namespace Devices.Web.API.Models.Entities
{
    public partial class DeviceStatus
    {
        public DeviceStatus()
        {
            Devices = new HashSet<Device>();
        }

        public int DeviceStatusId { get; set; }
        public string? Name { get; set; }

        public virtual ICollection<Device> Devices { get; set; }
    }
}
