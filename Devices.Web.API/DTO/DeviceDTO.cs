namespace Devices.Web.API.DTO
{
    public class DeviceDTO
    {
        public int DeviceId { get; set; }
        public int DeviceTypeId { get; set; }
        public int DeviceStatusId { get; set; }
        public string Name { get; set; } = null!;
        public short Temperature { get; set; }

        public string DeviceTypeName { get; set; } = null!;
        public string DeviceStatusName { get; set; } = null!;
        public List<int> DeviceUsage { get; set; } = null!;
    }
}
