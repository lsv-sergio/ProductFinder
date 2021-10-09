import { Component } from '@angular/core';
import {SearchService} from "./services";
import {FormControl, Validators} from "@angular/forms";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
	title = 'client-app';
	public searchValueControl: FormControl;
	constructor(private _searchService: SearchService) {
		this.searchValueControl = new FormControl('', [Validators.min(3), Validators.required])
	}
	public searchProduct() {
		this._searchService.find(this.searchValueControl.value)
			.subscribe(response => {
				debugger;
			})
	}
}
