import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SpecialitiesCreateEditComponent } from './specialities-create-edit.component';

describe('SpecialitiesCreateEditComponent', () => {
  let component: SpecialitiesCreateEditComponent;
  let fixture: ComponentFixture<SpecialitiesCreateEditComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [SpecialitiesCreateEditComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(SpecialitiesCreateEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
