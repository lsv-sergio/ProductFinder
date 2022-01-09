import {Injectable, OnDestroy} from '@angular/core';
import {SearchResponse} from "../models";
import {HubConnection} from "@microsoft/signalr";

export interface ClientIdProvider {
	get clientId(): string
}

@Injectable()
export class SignalRWrapperService implements OnDestroy, ClientIdProvider {

	private resultReceivedMessage = 'result-received';

	constructor(private _hubConnection: HubConnection) {
		_hubConnection.start()
			.then(() => console.log('Connection started'))
			.catch(err => console.log('Error while starting connection: ' + err));
	}

	public get clientId(): string {
		return this._hubConnection.connectionId || '';
	}

	public setResultReceivedHandler(onResultReceivedHandler: (searchResult: SearchResponse) => void) {
		this._hubConnection.on(this.resultReceivedMessage, (searchResult: SearchResponse) =>
			onResultReceivedHandler(searchResult));
	}

	public async ngOnDestroy(): Promise<void> {
		this._hubConnection.off(this.resultReceivedMessage);
		await this._hubConnection.stop();
	}
}
