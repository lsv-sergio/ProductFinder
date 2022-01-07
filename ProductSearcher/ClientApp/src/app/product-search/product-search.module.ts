import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {FoundResultComponent, SearchOptionsComponent} from "./components";
import {ProductSearchComponent} from './components/product-search/product-search.component';

@NgModule({
	declarations: [SearchOptionsComponent, FoundResultComponent, ProductSearchComponent],
	imports: [CommonModule]
})
export class ProductSearchModule {
}
