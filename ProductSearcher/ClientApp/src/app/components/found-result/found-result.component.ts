import {Component, Input, OnInit, ViewChild} from '@angular/core';
import {SearchResponse} from "../../models";
import {MatAccordion} from "@angular/material/expansion";

@Component({
  selector: 'app-found-result',
  templateUrl: './found-result.component.html',
  styleUrls: ['./found-result.component.scss']
})
export class FoundResultComponent implements OnInit {
	@ViewChild(MatAccordion, {static: true})private _accordion: MatAccordion | undefined;

	@Input()
	public searchResult: SearchResponse[] = [];

	public get hasResults(): boolean {
		return this.searchResult?.length > 0;
	};

	constructor() { }

	ngOnInit(): void {
	}

	public openAll() {
		this._accordion?.openAll();
	}

	public closeAll() {
		this._accordion?.closeAll();
	}
}
