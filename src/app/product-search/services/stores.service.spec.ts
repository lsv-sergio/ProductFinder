import {TestBed} from '@angular/core/testing';

import {ShopsService} from './shops.service';
import {HttpClientTestingModule} from '@angular/common/http/testing';

describe('StoresService', () => {
	let service: ShopsService;

	beforeEach(() => {
		TestBed.configureTestingModule({
			providers: [ShopsService],
			imports: [HttpClientTestingModule]
		});
		service = TestBed.inject(ShopsService);
	});

	it('should be created', () => {
		expect(service).toBeTruthy();
	});
});
