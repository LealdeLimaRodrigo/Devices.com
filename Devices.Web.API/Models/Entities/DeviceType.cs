using System;
using System.Collections.Generic;

namespace Devices.Web.API.Models.Entities
{
    public partial class DeviceType
    {
        public DeviceType()
        {
            Devices = new HashSet<Device>();
        }

        public int DeviceTypeId { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Device> Devices { get; set; }
    }
}
