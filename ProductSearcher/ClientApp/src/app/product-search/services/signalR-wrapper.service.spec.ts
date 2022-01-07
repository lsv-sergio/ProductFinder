import {TestBed} from '@angular/core/testing';

import {SignalRWrapperService} from './signalR-wrapper.service';

describe('SignalRWrapperService', () => {
	let service: SignalRWrapperService;

	beforeEach(() => {
		TestBed.configureTestingModule({});
		service = TestBed.inject(SignalRWrapperService);
	});

	it('should be created', () => {
		expect(service).toBeTruthy();
	});
});
