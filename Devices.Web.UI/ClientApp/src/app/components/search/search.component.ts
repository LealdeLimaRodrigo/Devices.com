import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.scss']
})
export class SearchComponent implements OnInit {

  @Input() devSearch!: string;
  @Output() devSearchChange = new EventEmitter<string>();  
  @Input() isEnabled: boolean = true;

  constructor() { }

  ngOnInit(): void {
  }

  searchDevices(value: string) {
    this.devSearch = value;
    this.devSearchChange.emit(this.devSearch);
  }

  checkEnabled() {
    if (this.isEnabled) {
      this.searchDevices('');
    }
  }

}
