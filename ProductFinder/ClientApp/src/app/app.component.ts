import { Component } from '@angular/core';
import {SearchService} from "./services";
import {FormControl, Validators} from "@angular/forms";
import {SearchResponse} from "./models";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
	constructor(private _searchService: SearchService) {
		this.searchValueControl = new FormControl('', [Validators.min(3), Validators.required])
	}
	public searchValueControl: FormControl;
	public searchResult: SearchResponse[] = [];
	public searchProduct() {
		this._searchService.find(this.searchValueControl.value)
			.subscribe(response => {
				this.searchResult = response
			});
	}
}
