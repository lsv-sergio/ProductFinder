import {NgModule} from "@angular/core";
import {Route, RouterModule} from "@angular/router";
import {ProductSearchComponent} from "./components/product-search/product-search.component";

const routes: Route[] = [{
	path: '**',
	component: ProductSearchComponent
}]
@NgModule({
	imports: [RouterModule.forChild(routes)],
	exports: [RouterModule]
})
export class ProductSearchRoutingModule {

}
