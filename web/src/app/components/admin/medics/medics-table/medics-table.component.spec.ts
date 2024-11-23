import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MedicsTableComponent } from './medics-table.component';

describe('MedicsTableComponent', () => {
  let component: MedicsTableComponent;
  let fixture: ComponentFixture<MedicsTableComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [MedicsTableComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(MedicsTableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
