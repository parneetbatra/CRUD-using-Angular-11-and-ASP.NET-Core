import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ComputerTypeService } from 'src/app/computer-type/computer-type.service';

@Component({
  selector: 'app-computer-type-update',
  templateUrl: './computer-type-update.component.html',
  styleUrls: ['./computer-type-update.component.css']
})
export class ComputerTypeUpdateComponent implements OnInit {
  id = 0;
  form: FormGroup;
  loading = false;

  constructor(
    private computerTypeService: ComputerTypeService,
    private formBuilder: FormBuilder,
    private activatedRoute: ActivatedRoute,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.form = this.formBuilder.group({
      id: new FormControl('', [Validators.required]),
      name: new FormControl('', [Validators.required])
    });

    this.activatedRoute.params.subscribe(params => {
      this.id = params.id;
    });

    this.computerTypeService.read(this.id)
      .subscribe(
        response => {

          this.form = this.formBuilder.group({
            id: new FormControl(response.id, [Validators.required]),
            name: new FormControl(response.name, [Validators.required])
          });
        },
        error => {
          console.log(error);
        });
  }

  get f() {
    return this.form.controls;
  }

  updateComputerType(): void {
    this.computerTypeService.update(this.form.value.id, this.form.value)
      .subscribe(
        response => {
          this.router.navigate(['/computer-type']);
        },
        error => {
          console.log(error);
        });
  }

}
