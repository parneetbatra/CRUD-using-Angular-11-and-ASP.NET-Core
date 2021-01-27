import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, FormControl, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';

import { PropertiesService } from 'src/app/properties/properties.service';
import { ComputerTypeService } from 'src/app/computer-type/computer-type.service';


@Component({
  selector: 'app-properties-update',
  templateUrl: './properties-update.component.html',
  styleUrls: ['./properties-update.component.css']
})
export class PropertiesUpdateComponent implements OnInit {
  id = 0;
  form: FormGroup;
  loading = false;

  computerTypes: Array<any> = [];

  constructor(
    private propertiesService: PropertiesService,
    private computerTypeService: ComputerTypeService,
    private formBuilder: FormBuilder,
    private activatedRoute: ActivatedRoute,
    private router: Router
  ) { }

  ngOnInit(): void {

    this.form = this.formBuilder.group({
      id: new FormControl('', [Validators.required]),
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

    this.activatedRoute.params.subscribe(params => {
      this.id = params.id;
    });

    this.propertiesService.read(this.id)
      .subscribe(
        response => {
          this.form = this.formBuilder.group({
            id: new FormControl(response.propertyId, [Validators.required]),
            computerTypeId: new FormControl(response.computerTypeId, [Validators.required]),
            processor: new FormControl(response.processor, [Validators.required]),
            brand: new FormControl(response.brand, [Validators.required]),
            usbPorts: new FormControl(response.usbPorts, [Validators.required]),
            ramSlots: new FormControl(response.ramSlots, [Validators.required]),
            fromFactor: new FormControl(response.fromFactor, [Validators.required]),
            quantity: new FormControl(response.quantity, [Validators.required]),
            screenSize: new FormControl(response.screenSize, [Validators.required])
          });
        },
        error => {
          console.log(error);
        });
  }

  get f() {
    return this.form.controls;
  }

  updateProperties(): void {
    this.loading = true;
    this.propertiesService.update(this.form.value.id, this.form.value)
      .subscribe(
        response => {
          this.loading = false;
          this.router.navigate(['/properties']);
        },
        error => {
          console.log(error);
        });
  }

}
