import {ComponentFixture, TestBed} from '@angular/core/testing';

import {FoundResultComponent} from './found-result.component';

describe('FoundResultComponent', () => {
  let component: FoundResultComponent;
  let fixture: ComponentFixture<FoundResultComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FoundResultComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(FoundResultComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
