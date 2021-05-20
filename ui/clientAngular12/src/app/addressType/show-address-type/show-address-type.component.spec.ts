import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShowAddressTypeComponent } from './show-address-type.component';

describe('ShowAddressTypeComponent', () => {
  let component: ShowAddressTypeComponent;
  let fixture: ComponentFixture<ShowAddressTypeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ShowAddressTypeComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ShowAddressTypeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
