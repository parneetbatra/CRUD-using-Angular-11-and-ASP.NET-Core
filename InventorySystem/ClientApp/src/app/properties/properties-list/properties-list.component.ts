import { Component, OnInit } from '@angular/core';
import { PropertiesService } from 'src/app/properties/properties.service';

@Component({
  selector: 'app-properties-list',
  templateUrl: './properties-list.component.html',
  styleUrls: ['./properties-list.component.css']
})
export class PropertiesListComponent implements OnInit {

  properties: any;
  currentComputerType = null;
  currentIndex = -1;
  name = '';

  constructor(private propertiesService: PropertiesService) { }

  ngOnInit(): void {
    this.readProperties();
  }

  readProperties(): void {
    this.propertiesService.readAll()
      .subscribe(
        res => {
          this.properties = res;
        },
        error => {
          console.log(error);
        });
  }

  refresh(): void {
    this.readProperties();
    this.currentComputerType = null;
    this.currentIndex = -1;
  }

  setCurrentProduct(product, index): void {
    this.currentComputerType = product;
    this.currentIndex = index;
  }

  deleteProperties(id): void {
    this.propertiesService.delete(id)
      .subscribe(
        res => {
          this.readProperties();
        },
        error => {
          console.log(error);
        });
  }

}
