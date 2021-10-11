import { Component } from '@angular/core';
import {SearchResponse} from "./models";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
	constructor() {}

	public searchResult: SearchResponse[] = [];

	onSearchSucceed(result: SearchResponse[]) {
		this.searchResult = result;
	}
}
