import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ManageclinicComponent } from './manageclinic.component';

describe('ManageclinicComponent', () => {
  let component: ManageclinicComponent;
  let fixture: ComponentFixture<ManageclinicComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ManageclinicComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ManageclinicComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
