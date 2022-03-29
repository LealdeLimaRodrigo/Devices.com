using System;
using System.Collections.Generic;

namespace Devices.Web.API.Models.Entities
{
    public partial class DeviceUsage
    {
        public int DeviceUsageId { get; set; }
        public int DeviceId { get; set; }
        public DateTime StartUsage { get; set; }
        public DateTime EndUsage { get; set; }

        public virtual Device Device { get; set; } = null!;
    }
}
