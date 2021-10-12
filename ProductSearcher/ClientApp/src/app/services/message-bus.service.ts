import {Injectable} from '@angular/core';
import {Observable, Subject} from "rxjs";
import {filter, map} from "rxjs/operators";
import * as signalR from "@microsoft/signalr";
import {SearchResponse} from "../models";

declare type MessageType = 'search_started' | 'result_received';

export interface Message<T = any> {
	type: MessageType,
	payload: T
}

export interface SearchStartedMessageData {
	searchOptions: string[]
}

export interface SearchResultData {
	result: SearchResponse
}

@Injectable({
	providedIn: 'root'
})
export class MessageBusService {

	private hubConnection: signalR.HubConnection;
	private _channel: Subject<Message> = new Subject<Message>()

	constructor() {
		this.hubConnection = new signalR.HubConnectionBuilder()
			.withUrl('/hub')
			.build();
		this.hubConnection
			.start()
			.then(() => console.log('Connection started'))
			.catch(err => console.log('Error while starting connection: ' + err));
		this.hubConnection.on('result-received', (searchResult: SearchResponse) => {
			this._channel.next({
				type: "result_received",
				payload: {result: searchResult} as SearchResultData
			} as Message)
		})
	}

	public get clientId(): string {
		return this.hubConnection.connectionId || '';
	}

	public publishMessage(message: Message) {
		this._channel.next(message);
	}

	public on<T = Message>(type: MessageType): Observable<T> {
		return this._channel.pipe(
			filter(message => message.type === type),
			map(message => message.payload))
	}
}
