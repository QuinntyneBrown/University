import { TestBed } from '@angular/core/testing';

import { CellphoneService } from './cellphone.service';

describe('CellphoneService', () => {
  let service: CellphoneService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CellphoneService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
