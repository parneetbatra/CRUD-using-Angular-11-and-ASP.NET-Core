import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ComputerTypeListComponent } from './computer-type-list.component';

describe('ComputerTypeListComponent', () => {
  let component: ComputerTypeListComponent;
  let fixture: ComponentFixture<ComputerTypeListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ComputerTypeListComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ComputerTypeListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
