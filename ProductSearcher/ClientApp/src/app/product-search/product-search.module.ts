import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {BrowserAnimationsModule} from "@angular/platform-browser/animations";
import {FoundResultComponent, SearchOptionsComponent} from "./components";
import {ProductSearchComponent} from './components/product-search/product-search.component';
import {ProductSearchRoutingModule} from "./product-search-routing.module";

@NgModule({
	declarations: [SearchOptionsComponent, FoundResultComponent, ProductSearchComponent],
	imports: [CommonModule, BrowserAnimationsModule, ProductSearchRoutingModule]
})
export class ProductSearchModule {
}
