import { Component, Input, OnInit } from '@angular/core';
import { Device } from 'src/app/view_models/device';

export class Icon {
  id!: number;
  class!: string;

  constructor(_id:number, _class: string) {
    this.id = _id;
    this.class = _class;
  }
}

@Component({
  selector: 'app-device-list',
  templateUrl: './device-list.component.html',
  styleUrls: ['./device-list.component.scss']
})
export class DeviceListComponent implements OnInit {

  icons: Icon[] = [
    new Icon(1, 'bi-display-fill'),
    new Icon(2, 'bi-laptop-fill'),
    new Icon(3, 'bi-phone-fill'),
    new Icon(4, 'bi-tablet-fill')
  ];

  class!: string;
  
  @Input() devices!: Device[];
  @Input() devSearch!: string;
  @Input() details?: boolean = false;

  constructor() { }

  ngOnInit(): void {
    
  }

  getClass(typeId: number) : string {
    var c = this.icons.find(x => x.id == typeId)?.class + " icon_font";
    return c;
  }

}
