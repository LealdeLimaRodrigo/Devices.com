import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { forkJoin } from 'rxjs';
import { DeviceService } from 'src/app/services/device.service';
import { JsonService } from 'src/app/services/json.service';
import { Device } from 'src/app/view_models/device';

@Component({
  selector: 'app-device-details',
  templateUrl: './device-details.component.html',
  styleUrls: ['./device-details.component.scss']
})
export class DeviceDetailsComponent implements OnInit {

  isLoading = true;
  deviceId!: number;
  device!: Device;

  devices: Device[] = [];

  constructor(private activatedRoute: ActivatedRoute, private deviceService: DeviceService, private router: Router, private jsonService: JsonService) { 
    this.deviceId = this.activatedRoute.snapshot.params['id'];
    this.router.routeReuseStrategy.shouldReuseRoute = () => {
      return false;
    };
  }

  ngOnInit(): void {
    this.loadDetailsJson();
  }

  loadDetails() {
    let getDeviceById = this.deviceService.getDeviceById(this.deviceId);
    let getRelatedDevices = this.deviceService.getRelatedDevices();

    forkJoin([getDeviceById, getRelatedDevices]).subscribe(results => {
      this.device = results[0];
      this.devices = results[1];
      const index = this.devices.indexOf((this.devices.find(x => x.deviceId == this.deviceId) as Device), 0);
      if (index > -1) {
        this.devices.splice(index, 1);
      }
    });
  }
  
  loadDetailsJson() {
    let getDeviceById = this.jsonService.getDeviceById(this.deviceId);
    let getRelatedDevices = this.jsonService.getRelatedDevices();

    forkJoin([getDeviceById, getRelatedDevices]).subscribe(results => {
      this.device = results[0];
      this.devices = results[1];
    });
  }

}
