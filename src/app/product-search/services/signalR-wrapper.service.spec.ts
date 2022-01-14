import {TestBed} from '@angular/core/testing';

import {SignalRWrapperService} from './signalR-wrapper.service';
import {HubConnection} from "@microsoft/signalr";

describe('SignalRWrapperService', () => {
	let service: SignalRWrapperService;

	beforeEach(() => {
		TestBed.configureTestingModule({
			providers: [
				SignalRWrapperService,
				{
					provide: HubConnection,
					useValue: {
						start: () => Promise.resolve({}),
						stop: () => Promise.resolve({}),
						on: () => {},
						off: () => {},
						connectionId: ''
					}
				}
			]
		});
		service = TestBed.inject(SignalRWrapperService);
	});

	it('should be created', () => {
		expect(service).toBeTruthy();
	});
});
