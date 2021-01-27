import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ComputerTypeUpdateComponent } from './computer-type-update.component';

describe('ComputerTypeUpdateComponent', () => {
  let component: ComputerTypeUpdateComponent;
  let fixture: ComponentFixture<ComputerTypeUpdateComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ComputerTypeUpdateComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ComputerTypeUpdateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
