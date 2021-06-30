import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TodaysappointmentComponent } from './todaysappointment.component';

describe('TodaysappointmentComponent', () => {
  let component: TodaysappointmentComponent;
  let fixture: ComponentFixture<TodaysappointmentComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TodaysappointmentComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TodaysappointmentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
