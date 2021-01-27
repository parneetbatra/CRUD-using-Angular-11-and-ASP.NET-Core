import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ComputerTypeCreateComponent } from './computer-type-create.component';

describe('ComputerTypeCreateComponent', () => {
  let component: ComputerTypeCreateComponent;
  let fixture: ComponentFixture<ComputerTypeCreateComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ComputerTypeCreateComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ComputerTypeCreateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
