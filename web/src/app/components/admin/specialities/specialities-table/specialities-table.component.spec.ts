import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SpecialitiesTableComponent } from './specialities-table.component';

describe('SpecialitiesTableComponent', () => {
  let component: SpecialitiesTableComponent;
  let fixture: ComponentFixture<SpecialitiesTableComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [SpecialitiesTableComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(SpecialitiesTableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
