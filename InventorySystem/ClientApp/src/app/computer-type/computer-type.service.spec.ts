import { TestBed } from '@angular/core/testing';

import { ComputerTypeService } from './computer-type.service';

describe('ComputerTypeService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: ComputerTypeService = TestBed.get(ComputerTypeService);
    expect(service).toBeTruthy();
  });
});
