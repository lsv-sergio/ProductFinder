import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProductSearchComponent } from './product-search.component';
import {SearchOptionsComponent} from '../search-options/search-options.component';
import {FoundResultComponent} from '../found-result/found-result.component';
import {CommonModule} from '@angular/common';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatInputModule} from '@angular/material/input';
import {MatIconModule} from '@angular/material/icon';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import {MatGridListModule} from '@angular/material/grid-list';
import {MatBadgeModule} from '@angular/material/badge';
import {MatCardModule} from '@angular/material/card';
import {MatButtonModule} from '@angular/material/button';
import {MatExpansionModule} from '@angular/material/expansion';
import {MatSlideToggleModule} from '@angular/material/slide-toggle';
import {MatProgressSpinnerModule} from '@angular/material/progress-spinner';
import {HttpClientTestingModule} from '@angular/common/http/testing';
import {MessageBusService, SearchService} from '../../services';
import {EMPTY, of} from 'rxjs';
import {CLIENT_ID_TOKEN} from '../../models';
import {NoopAnimationsModule} from '@angular/platform-browser/animations';

describe('ProductSearchComponent', () => {
	let component: ProductSearchComponent;
	let fixture: ComponentFixture<ProductSearchComponent>;

	beforeEach(async () => {
		await TestBed.configureTestingModule({
			imports: [
				CommonModule,
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
				HttpClientTestingModule
			],
			declarations: [ ProductSearchComponent, SearchOptionsComponent, FoundResultComponent ],
			providers: [
				{
					provide: SearchService,
					useValue: {
						find: () => of({})
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
		fixture = TestBed.createComponent(ProductSearchComponent);
		component = fixture.componentInstance;
		fixture.detectChanges();
	});

	it('should create', () => {
		expect(component).toBeTruthy();
	});
});
