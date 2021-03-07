import { TestBed } from '@angular/core/testing';

import { ConfigSettingServiceService } from './config-setting-service.service';

describe('ConfigSettingServiceService', () => {
  let service: ConfigSettingServiceService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ConfigSettingServiceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
