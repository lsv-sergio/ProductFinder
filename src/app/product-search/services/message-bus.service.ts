import {Injectable} from '@angular/core';
import {Observable, Subject} from 'rxjs';
import {filter, map} from 'rxjs/operators';
import {SearchResponse} from '../models';
import {SignalRWrapperService} from './signalR-wrapper.service';

declare type MessageType = 'search_started' | 'result_received';

//eslint-disable-next-line  @typescript-eslint/no-explicit-any
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

	private _channel: Subject<Message> = new Subject<Message>();

	constructor(private _signalRWrapper: SignalRWrapperService) {
		_signalRWrapper.setResultReceivedHandler(this._onResultReceivedHandler.bind(this));
	}

	private _onResultReceivedHandler(searchResult: SearchResponse) {
		this._channel.next({
			type: 'result_received',
			payload: {result: searchResult} as SearchResultData
		} as Message);
	}

	public publishMessage(message: Message) {
		this._channel.next(message);
	}

	public on<T = Message>(type: MessageType): Observable<T> {
		return this._channel.pipe(
			filter(message => message.type === type),
			map(message => message.payload));
	}
}
