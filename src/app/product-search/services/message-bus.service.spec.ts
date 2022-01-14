import {TestBed} from '@angular/core/testing';

import {MessageBusService} from './message-bus.service';
import {SignalRWrapperStubService} from './signalR-wrapper-stub.service';
import {SignalRWrapperService} from './signalR-wrapper.service';

describe('MessageBusService', () => {
	let service: MessageBusService;

	beforeEach(() => {
		TestBed.configureTestingModule({
			providers: [
				MessageBusService,
				{
					provide:SignalRWrapperService,
					useClass: SignalRWrapperStubService
				}
			]
		});
		service = TestBed.inject(MessageBusService);
	});

	it('should be created', () => {
		expect(service).toBeTruthy();
	});
});
