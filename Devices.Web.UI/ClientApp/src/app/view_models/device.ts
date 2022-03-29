
export class Device {
    deviceId!: number;
    deviceTypeId!: number;
    deviceStatusId!: number;
    name!: string;
    temperature!: number;
    usage?: number [];
    deviceTypeName!: string;
    deviceStatusName!: string;

    constructor(_deviceId: number, _deviceTypeId: number, _deviceStatusId: number, _name: string, _temperature: number, _deviceTypeName: string, _deviceStatusName: string, _usage?: number[]) {
        this.deviceId = _deviceId;
        this.deviceTypeId = _deviceTypeId;
        this.deviceStatusId = _deviceStatusId;
        this.name = _name;
        this.temperature = _temperature;
        this.usage = this.usage;
        this.deviceTypeName = _deviceTypeName;
        this.deviceStatusName = _deviceStatusName;
     }
}