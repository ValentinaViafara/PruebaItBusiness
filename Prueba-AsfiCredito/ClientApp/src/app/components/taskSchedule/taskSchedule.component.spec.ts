import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { taskScheduleComponent } from './taskSchedule.component';

describe('taskScheduleComponent', () => {
  let component: taskScheduleComponent;
  let fixture: ComponentFixture<taskScheduleComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ taskScheduleComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(taskScheduleComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
