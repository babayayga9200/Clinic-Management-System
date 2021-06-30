import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InavbarComponent } from './inavbar.component';

describe('InavbarComponent', () => {
  let component: InavbarComponent;
  let fixture: ComponentFixture<InavbarComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ InavbarComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(InavbarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
