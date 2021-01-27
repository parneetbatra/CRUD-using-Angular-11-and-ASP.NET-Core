import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ComputerTypeService } from 'src/app/computer-type/computer-type.service';

@Component({
  selector: 'app-computer-type-create',
  templateUrl: './computer-type-create.component.html',
  styleUrls: ['./computer-type-create.component.css']
})
export class ComputerTypeCreateComponent implements OnInit {
  form: FormGroup;
  loading = false;

  constructor(
    private computerTypeService: ComputerTypeService,
    private formBuilder: FormBuilder,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.form = this.formBuilder.group({
      name: new FormControl('', [Validators.required])
    });
  }

  get f() {
    return this.form.controls;
  }

  createComputerType(): void {
    this.loading = true;
    this.computerTypeService.create(this.form.value)
      .subscribe(
        response => {
          this.loading = false;
          this.router.navigate(['/computer-type']);
        },
        error => {
          console.log(error);
        });
  }
}
