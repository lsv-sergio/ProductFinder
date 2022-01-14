import {ComponentFixture, TestBed} from '@angular/core/testing';

import {FoundResultComponent} from './found-result.component';
import {MessageBusService} from "../../services";
import {MatAccordion, MatExpansionModule} from "@angular/material/expansion";
import {MatFormFieldModule} from "@angular/material/form-field";
import {MatInputModule} from "@angular/material/input";
import {MatIconModule} from "@angular/material/icon";
import {FormsModule, ReactiveFormsModule} from "@angular/forms";
import {MatGridListModule} from "@angular/material/grid-list";
import {MatBadgeModule} from "@angular/material/badge";
import {MatCardModule} from "@angular/material/card";
import {MatButtonModule} from "@angular/material/button";
import {MatSlideToggleModule} from "@angular/material/slide-toggle";
import {MatProgressSpinnerModule} from "@angular/material/progress-spinner";
import {CommonModule} from "@angular/common";
import {BrowserAnimationsModule, NoopAnimationsModule} from "@angular/platform-browser/animations";
import {EMPTY, of} from "rxjs";

describe('FoundResultComponent', () => {
  let component: FoundResultComponent;
  let fixture: ComponentFixture<FoundResultComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FoundResultComponent ],
		imports: [
			NoopAnimationsModule,
			MatFormFieldModule,
			MatInputModule,
			MatIconModule,
			FormsModule,
			ReactiveFormsModule,
			MatGridListModule,
			MatBadgeModule,
			MatCardModule,
			MatButtonModule,
			MatExpansionModule,
			MatSlideToggleModule,
			MatProgressSpinnerModule,
		],
		providers: [
			{
				provide: MessageBusService,
				useValue: {
					on: () => EMPTY
				}
			}
		]
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
