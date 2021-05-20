import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddEditAddressTypeComponent } from './add-edit-address-type.component';

describe('AddEditAddressTypeComponent', () => {
  let component: AddEditAddressTypeComponent;
  let fixture: ComponentFixture<AddEditAddressTypeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddEditAddressTypeComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddEditAddressTypeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
