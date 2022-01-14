import {Injectable} from '@angular/core';
import {ClientIdProvider} from './signalR-wrapper.service';
import {SearchResponse} from '../models';

@Injectable()
export class SignalRWrapperStubService implements ClientIdProvider {

	public get clientId(): string {
		return '';
	}

	public setResultReceivedHandler(onResultReceivedHandler: (searchResult: SearchResponse) => void) {
		onResultReceivedHandler(<SearchResponse>{});
	}

}
