import { Component, OnInit } from '@angular/core';
import { DeviceService } from 'src/app/services/device.service';
import { JsonService } from 'src/app/services/json.service';
import { Device } from 'src/app/view_models/device';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

  devSearch: string = "";
  devices: Device[] = [];

  constructor(private deviceService: DeviceService, private jsonService: JsonService) {
    
   }

  ngOnInit(): void {
    this.getDevicesJson();
  }

  getDevices() {
    this.deviceService.getDevices().subscribe({
      next: x => this.devices = x,
      error: e => console.log(e)
    });
  }
  
  getDevicesJson() {
    this.jsonService.getDevices().subscribe({
      next: x => this.devices = x,
      error: e => console.log(e)
    });
  }

  search(textSearch: string) {
    this.devSearch = textSearch;
  }

}
