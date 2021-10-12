import {Component, OnDestroy, OnInit, ViewChild} from '@angular/core';
import {SearchResponse} from "../../models";
import {MatAccordion} from "@angular/material/expansion";
import {MessageBusService, SearchResultData, SearchStartedMessageData} from "../../services";
import {takeUntil} from "rxjs/operators";
import {Subject} from "rxjs";

@Component({
	selector: 'app-found-result',
	templateUrl: './found-result.component.html',
	styleUrls: ['./found-result.component.scss']
})
export class FoundResultComponent implements OnInit, OnDestroy {
	@ViewChild(MatAccordion, {static: true}) private _accordion: MatAccordion | undefined;
	private destroyed: Subject<void> = new Subject<void>();

	constructor(private _messageBusService: MessageBusService) {
	}

	public searchResult: SearchResponse[] = [];

	public get hasResults(): boolean {
		return this.searchResult?.length > 0;
	};

	ngOnInit(): void {
		this._messageBusService.on<SearchStartedMessageData>('search_started')
			.pipe(takeUntil(this.destroyed))
			.subscribe(message => this._onSearchStartedReceived(message));
		this._messageBusService.on<SearchResultData>('result_received')
			.pipe(takeUntil(this.destroyed))
			.subscribe(message => this._onSearchResultReceived(message));

	}

	public openAll() {
		this._accordion?.openAll();
	}

	public closeAll() {
		this._accordion?.closeAll();
	}

	ngOnDestroy(): void {
		this.destroyed.next();
		this.destroyed.complete();
	}

	private _onSearchStartedReceived(messageData: SearchStartedMessageData) {
		this.searchResult = messageData.searchOptions.map(shop => {
			return {storeName: shop, products: []} as SearchResponse
		});
	}

	private _onSearchResultReceived(messageData: SearchResultData) {
		const currentResults = this.searchResult.filter(result => result.storeName !== messageData.result.storeName);
		this.searchResult = [
			messageData.result,
			...currentResults
		];
	}
}
