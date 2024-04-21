import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EmergencyCallComponent } from './emergency-call.component';

describe('EmergencyCallComponent', () => {
  let component: EmergencyCallComponent;
  let fixture: ComponentFixture<EmergencyCallComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [EmergencyCallComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(EmergencyCallComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
