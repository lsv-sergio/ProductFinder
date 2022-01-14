import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';
import {SearchResponse} from '../models';

@Injectable({
	providedIn: 'root'
})
export class SearchService {

	constructor(private _httpClient: HttpClient) {}

	public find(productName: string, clientId: string, searchOptions: string[]): Observable<SearchResponse[]> {
		return this._httpClient.post<SearchResponse[]>('api/search', {
			'productName': productName,
			'searchIn': searchOptions,
			'clientId': clientId
		});
	}
}
