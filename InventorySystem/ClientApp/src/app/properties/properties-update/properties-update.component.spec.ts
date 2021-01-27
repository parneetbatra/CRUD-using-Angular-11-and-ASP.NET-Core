import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PropertiesUpdateComponent } from './properties-update.component';

describe('PropertiesUpdateComponent', () => {
  let component: PropertiesUpdateComponent;
  let fixture: ComponentFixture<PropertiesUpdateComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PropertiesUpdateComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PropertiesUpdateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
