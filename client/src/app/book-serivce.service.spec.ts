import { TestBed } from '@angular/core/testing';

import { BookSerivceService } from './book-serivce.service';

describe('BookSerivceService', () => {
  let service: BookSerivceService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(BookSerivceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
