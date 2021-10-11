import {Component, OnInit} from '@angular/core';
import {SearchService} from "./services";
import {FormArray, FormControl, FormGroup, Validators} from "@angular/forms";
import {SearchResponse} from "./models";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
	constructor(private _searchService: SearchService) {
		this.search = new FormGroup({
			options: new FormArray([]),
			searchValue: new FormControl('', [Validators.min(3), Validators.required])
		});
	}

	public finders: string[] = ['Atb', 'Varus'];
	public search: FormGroup;
	public get searchOptionsFormArray() {
		return this.search.controls.options as FormArray;
	}
	public searchResult: SearchResponse[] = [];
	public searchProduct() {
		debugger;
		const searchOptions = this.search.value.options
			.map((checked: boolean, i: number) => checked ? this.finders[i] : null)
				.filter((value: string) => value);

		this._searchService.find(this.search.get('searchValue')?.value, searchOptions)
			.subscribe(response => {
				this.searchResult = response
			});
	}

	public ngOnInit(): void {
		const options = this.searchOptionsFormArray;
		this.finders.forEach(() => {
			options.push(new FormControl(true))
		});
	}

}
