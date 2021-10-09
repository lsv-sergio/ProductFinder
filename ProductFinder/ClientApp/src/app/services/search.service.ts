import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";

@Injectable({
  providedIn: 'root'
})
export class SearchService {

  constructor(private _httpClient: HttpClient) {}

  public find(productName: string): Observable<any> {
    return this._httpClient.get(`api/search/${productName}`);
  }
}
