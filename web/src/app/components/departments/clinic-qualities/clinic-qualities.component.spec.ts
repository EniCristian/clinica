import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ClinicQualitiesComponent } from './clinic-qualities.component';

describe('ClinicQualitiesComponent', () => {
  let component: ClinicQualitiesComponent;
  let fixture: ComponentFixture<ClinicQualitiesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ClinicQualitiesComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ClinicQualitiesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
