import {Injectable} from '@angular/core';
import {Observable} from "rxjs";
import {Store} from "../models";
import {HttpClient} from "@angular/common/http";

@Injectable({
  providedIn: 'root'
})
export class StoresService {

  constructor(private _httpClient: HttpClient) { }

	getStores(): Observable<Store[]> {
		return this._httpClient.get<Store[]>('api/stores');
	}
}
