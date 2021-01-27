import { Component, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { ComputerTypeService } from 'src/app/computer-type/computer-type.service';

@Component({
  selector: 'app-computer-type-list',
  templateUrl: './computer-type-list.component.html',
  styleUrls: ['./computer-type-list.component.css']
})
export class ComputerTypeListComponent implements OnInit {
  computerTypes: any;
  currentComputerType = null;
  currentIndex = -1;
  name = '';

  constructor(private computerTypeService: ComputerTypeService) { }

  ngOnInit(): void {
    this.readComputerTypes();
  }

  readComputerTypes(): void {
    this.computerTypeService.readAll()
      .subscribe(
        res => {
          this.computerTypes = res;
        },
        error => {
          console.log(error);
        });
  }

  refresh(): void {
    this.readComputerTypes();
    this.currentComputerType = null;
    this.currentIndex = -1;
  }

  setCurrentProduct(product, index): void {
    this.currentComputerType = product;
    this.currentIndex = index;
  }

  deleteComputerTypes(id): void {
    this.computerTypeService.delete(id)
      .subscribe(
        res => {
          this.readComputerTypes();
        },
        error => {
          console.log(error);
        });
  }

}