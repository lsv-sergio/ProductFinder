import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';

const routes: Routes = [
	{
		path: 'product-search',
		loadChildren: () => import('../app/product-search/product-search.module').then(m => m.ProductSearchModule)
	},
	{
		path: '',
		pathMatch: 'full',
		redirectTo: 'product-search'
	}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
