import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ClinicQualityComponent } from './clinic-quality.component';

describe('ClinicQualityComponent', () => {
  let component: ClinicQualityComponent;
  let fixture: ComponentFixture<ClinicQualityComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ClinicQualityComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ClinicQualityComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
