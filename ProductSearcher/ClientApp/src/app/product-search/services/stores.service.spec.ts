import {TestBed} from '@angular/core/testing';

import {ShopsService} from './shops.service';

describe('StoresService', () => {
	let service: ShopsService;

	beforeEach(() => {
		TestBed.configureTestingModule({});
		service = TestBed.inject(ShopsService);
	});

	it('should be created', () => {
		expect(service).toBeTruthy();
	});
});
