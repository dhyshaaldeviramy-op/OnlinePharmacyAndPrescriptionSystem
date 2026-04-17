import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PrescriptionApproval } from './prescription-approval';

describe('PrescriptionApproval', () => {
  let component: PrescriptionApproval;
  let fixture: ComponentFixture<PrescriptionApproval>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [PrescriptionApproval]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PrescriptionApproval);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
