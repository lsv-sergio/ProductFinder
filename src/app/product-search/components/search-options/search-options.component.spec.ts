import {ComponentFixture, TestBed} from '@angular/core/testing';

import {SearchOptionsComponent} from './search-options.component';
import {MessageBusService, SearchService, ShopsService} from "../../services";
import {EMPTY, of} from "rxjs";
import {CLIENT_ID_TOKEN} from "../../models";
import {MatFormFieldModule} from "@angular/material/form-field";
import {MatIconModule} from "@angular/material/icon";
import {FormsModule, ReactiveFormsModule} from "@angular/forms";
import {MatInputModule} from "@angular/material/input";
import {NoopAnimationsModule} from "@angular/platform-browser/animations";

describe('SearchOptionsComponent', () => {
  let component: SearchOptionsComponent;
  let fixture: ComponentFixture<SearchOptionsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SearchOptionsComponent ],
		imports: [
			NoopAnimationsModule,
			MatIconModule,
			FormsModule,
			ReactiveFormsModule,
			MatFormFieldModule,
			MatInputModule,
		],
		providers: [
			{
				provide: SearchService,
				useValue: {
					find: () => of({})
				},
			},
			{
				provide: ShopsService,
				useValue: {
					getStores: () => of({})
				},
			},
			{
				provide: MessageBusService,
				useValue: {
					on: () => EMPTY
				}
			},
			{
				provide: CLIENT_ID_TOKEN,
				useValue: {
					clientId: ''
				}
			}
		]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SearchOptionsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
