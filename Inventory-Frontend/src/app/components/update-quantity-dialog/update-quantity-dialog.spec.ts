import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UpdateQuantityDialog } from './update-quantity-dialog';

describe('UpdateQuantityDialog', () => {
  let component: UpdateQuantityDialog;
  let fixture: ComponentFixture<UpdateQuantityDialog>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [UpdateQuantityDialog]
    })
    .compileComponents();

    fixture = TestBed.createComponent(UpdateQuantityDialog);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
