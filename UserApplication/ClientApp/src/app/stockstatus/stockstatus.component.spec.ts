import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { StockStatusComponent } from './stockstatus.component';

describe('StockstatusComponent', () => {
  let component: StockStatusComponent;
  let fixture: ComponentFixture<StockStatusComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [StockStatusComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(StockStatusComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
