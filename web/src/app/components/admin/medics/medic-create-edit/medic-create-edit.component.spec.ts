import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MedicCreateEditComponent } from './medic-create-edit.component';

describe('MedicCreateEditComponent', () => {
  let component: MedicCreateEditComponent;
  let fixture: ComponentFixture<MedicCreateEditComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [MedicCreateEditComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(MedicCreateEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
