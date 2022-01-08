import {NgModule} from '@angular/core';

import {AppRoutingModule} from './app-routing.module';
import {AppComponent} from './app.component';
import {CommonModule} from "@angular/common";
import {BrowserAnimationsModule} from "@angular/platform-browser/animations";

@NgModule({
	declarations: [
		AppComponent,
	],
	imports: [
		CommonModule,
		AppRoutingModule,
		BrowserAnimationsModule
	],
	bootstrap: [AppComponent]
})
export class AppModule { }
