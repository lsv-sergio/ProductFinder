import {NgModule, Provider} from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProductSearchComponent } from './components/product-search/product-search.component';
import {SearchOptionsComponent} from './components/search-options/search-options.component';
import {FoundResultComponent} from './components/found-result/found-result.component';
import {MatIconModule} from '@angular/material/icon';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatInputModule} from '@angular/material/input';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import {MatGridListModule} from '@angular/material/grid-list';
import {MatBadgeModule} from '@angular/material/badge';
import {MatCardModule} from '@angular/material/card';
import {MatButtonModule} from '@angular/material/button';
import {MatExpansionModule} from '@angular/material/expansion';
import {MatSlideToggleModule} from '@angular/material/slide-toggle';
import {MatProgressSpinnerModule} from '@angular/material/progress-spinner';
import {SignalRWrapperService} from './services';
import {CLIENT_ID_TOKEN} from './models';
import * as signalR from '@microsoft/signalr';
import {HubConnection} from '@microsoft/signalr';
import {ProductSearchRoutingModule} from './product-search-routing.module';
import {MessageBusService, SearchService, ShopsService} from './services';
import {environment} from '../../environments/environment';
import {SignalRWrapperStubService} from './services';

const providers: Provider[] = [
	MessageBusService,
	SearchService,
	ShopsService,
	{
		provide: CLIENT_ID_TOKEN,
		useFactory: (signalRWrapperService: SignalRWrapperService) => signalRWrapperService,
		deps: [SignalRWrapperService]
	}
];
if (environment.production) {
	const signalRHubConnection = new signalR.HubConnectionBuilder()
		.withUrl('/hub')
		.build();
	providers.push(	SignalRWrapperService);
	providers.push({
		provide: HubConnection,
		useFactory: () => signalRHubConnection
	},
	);
} else {
	providers.push({
		provide: SignalRWrapperService,
		useClass: SignalRWrapperStubService
	});
}
@NgModule({
	declarations: [
		ProductSearchComponent,
		SearchOptionsComponent,
		FoundResultComponent
	],
	imports: [
		CommonModule,
		ProductSearchRoutingModule,
		MatFormFieldModule,
		MatInputModule,
		MatIconModule,
		FormsModule,
		ReactiveFormsModule,
		MatGridListModule,
		MatBadgeModule,
		MatCardModule,
		MatButtonModule,
		MatExpansionModule,
		MatSlideToggleModule,
		MatProgressSpinnerModule,
	],
	providers: providers,
})
export class ProductSearchModule { }
