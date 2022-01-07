import {Injectable} from '@angular/core';
import {Observable} from "rxjs";
import {Shop} from "../models";
import {HttpClient} from "@angular/common/http";

@Injectable({
	providedIn: 'root'
})
export class ShopsService {

	constructor(private _httpClient: HttpClient) {
	}

	getStores(): Observable<Shop[]> {
		return this._httpClient.get<Shop[]>('api/shops');
	}
}
