import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, FormControl, Validators } from '@angular/forms';

import { PropertiesService } from 'src/app/properties/properties.service';
import { ComputerTypeService } from 'src/app/computer-type/computer-type.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-properties-create',
  templateUrl: './properties-create.component.html',
  styleUrls: ['./properties-create.component.css']
})
export class PropertiesCreateComponent implements OnInit {
  form: FormGroup;
  loading = false;

  computerTypes: Array<any> = [];

  constructor(
    private propertiesService: PropertiesService,
    private computerTypeService: ComputerTypeService,
    private formBuilder: FormBuilder,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.form = this.formBuilder.group({
      computerTypeId: new FormControl('', [Validators.required]),
      processor: new FormControl('', [Validators.required]),
      brand: new FormControl('', [Validators.required]),
      usbPorts: new FormControl('', [Validators.required]),
      ramSlots: new FormControl('', [Validators.required]),
      fromFactor: new FormControl('', [Validators.required]),
      quantity: new FormControl('', [Validators.required]),
      screenSize: new FormControl('', [Validators.required])
    });

    this.computerTypeService.readAll()
      .subscribe(
        response => {
          this.computerTypes = response;
        },
        error => {
          console.log(error);
        });
  }

  get f() {
    return this.form.controls;
  }

  createProperties(): void {
    this.loading = true;
    this.propertiesService.create(this.form.value)
      .subscribe(
        response => {
          this.loading = false;
          this.form.reset();
          this.router.navigate(['/properties']);
        },
        error => {
          console.log(error);
        });
  }
}
