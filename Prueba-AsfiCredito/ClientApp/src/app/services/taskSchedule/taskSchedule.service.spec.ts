import { TestBed } from '@angular/core/testing';

import { TaskSchedule } from './taskSchedule.service';

describe('taskSchedule', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: TaskSchedule = TestBed.get(TaskSchedule);
    expect(service).toBeTruthy();
  });
});
