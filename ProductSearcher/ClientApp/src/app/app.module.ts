import {NgModule} from '@angular/core';
import {BrowserModule} from '@angular/platform-browser';

import {AppRoutingModule} from './app-routing.module';
import {AppComponent} from './app.component';
import {MatFormFieldModule} from "@angular/material/form-field";
import {MatInputModule} from "@angular/material/input";
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import {MatIconModule} from "@angular/material/icon";
import {FormsModule, ReactiveFormsModule} from "@angular/forms";
import {HttpClientModule} from "@angular/common/http";
import {FoundResultComponent} from './components/found-result/found-result.component';
import {MatGridListModule} from "@angular/material/grid-list";
import {MatBadgeModule} from "@angular/material/badge";
import {MatCardModule} from "@angular/material/card";
import {MatButtonModule} from "@angular/material/button";
import {MatExpansionModule} from "@angular/material/expansion";
import {MatSlideToggleModule} from "@angular/material/slide-toggle";
import {MatProgressSpinnerModule} from "@angular/material/progress-spinner";
import {SearchOptionsComponent} from './components/search-options/search-options.component';
import * as signalR from "@microsoft/signalr";
import {HubConnection} from "@microsoft/signalr";
import {CLIENT_ID_TOKEN} from "./models";
import {SignalRWrapperService} from "./services/signalR-wrapper.service";

const signalRHubConnection = new signalR.HubConnectionBuilder()
	.withUrl('/hub')
	.build();

@NgModule({
	declarations: [
		AppComponent,
		FoundResultComponent,
		SearchOptionsComponent
	],
	imports: [
		BrowserModule,
		AppRoutingModule,
		MatFormFieldModule,
		MatInputModule,
		BrowserAnimationsModule,
		MatIconModule,
		FormsModule,
		HttpClientModule,
		ReactiveFormsModule,
		MatGridListModule,
		MatBadgeModule,
		MatCardModule,
		MatButtonModule,
		MatExpansionModule,
		MatSlideToggleModule,
		MatProgressSpinnerModule
	],
	providers: [
		SignalRWrapperService,
		{
			provide: HubConnection,
			useFactory: () => signalRHubConnection
		},
		{
			provide: CLIENT_ID_TOKEN,
			useFactory: (signalRWrapperService: SignalRWrapperService) => signalRWrapperService,
			deps: [SignalRWrapperService]
		}
	],
	bootstrap: [AppComponent]
})
export class AppModule { }
