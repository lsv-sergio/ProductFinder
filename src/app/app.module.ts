import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import {MatToolbarModule} from '@angular/material/toolbar';
import {MatButtonModule} from '@angular/material/button';
import {CommonModule} from '@angular/common';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import {environment} from '../environments/environment';
import {HTTP_INTERCEPTORS, HttpClientModule} from '@angular/common/http';
import {BackendInterceptorMock} from './mocks/backend-interceptor-mock';

const providers = [];
if (!environment.production) {
	providers.push({
		provide: HTTP_INTERCEPTORS,
		useClass: BackendInterceptorMock,
		multi: true
	});
}
@NgModule({
	declarations: [
		AppComponent
	],
	imports: [
		CommonModule,
		BrowserAnimationsModule,
		AppRoutingModule,
		HttpClientModule,
		MatToolbarModule,
		MatButtonModule
	],
	providers: providers,
	bootstrap: [AppComponent]
})
export class AppModule { }
