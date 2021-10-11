import {Component, EventEmitter, OnInit, Output} from '@angular/core';
import {FormArray, FormControl, FormGroup, Validators} from "@angular/forms";
import {SearchResponse, Store} from "../../models";
import {SearchService, StoresService} from "../../services";

@Component({
  selector: 'app-search-options',
  templateUrl: './search-options.component.html',
  styleUrls: ['./search-options.component.scss']
})
export class SearchOptionsComponent implements OnInit {
	public get searchOptionsFormArray() {
		return this.search.controls.options as FormArray;
	}
	constructor(private _searchService: SearchService, private _storesService: StoresService) {
		this.search = new FormGroup({
			options: new FormArray([]),
			searchValue: new FormControl('', [Validators.min(3), Validators.required])
		});
	}

	@Output()
	public onSearchSucceed: EventEmitter<SearchResponse[]> = new EventEmitter<SearchResponse[]>();
	public stores: Store[] = [];
	public search: FormGroup;
	public inProgress: boolean = false;

	ngOnInit(): void {
		this._storesService.getStores()
			.subscribe(response => {
				debugger;
				this.stores = response
				const options = this.searchOptionsFormArray;
				this.stores.forEach(() => {
					options.push(new FormControl(true))
				});
			});
	}
	public searchProduct() {
		const searchOptions = this.search.value.options
			.map((checked: boolean, i: number) => checked ? this.stores[i].name : null)
			.filter((value: string) => value);
		this._searchService.find(this.search.get('searchValue')?.value, searchOptions)
			.subscribe(response => {
				this.onSearchSucceed.emit(response);
			});
	}
}
