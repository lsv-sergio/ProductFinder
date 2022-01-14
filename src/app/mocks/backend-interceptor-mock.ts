import {HttpEvent, HttpHandler, HttpInterceptor, HttpRequest, HttpResponse} from '@angular/common/http';
import {Observable, of} from 'rxjs';
import {Shop} from '../product-search/models';
import {Injectable} from '@angular/core';

@Injectable()
export class BackendInterceptorMock implements HttpInterceptor {
//eslint-disable-next-line  @typescript-eslint/no-explicit-any
	public intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
		if (req.url.endsWith('shops')) {
			return of(<HttpResponse<Shop[]>> {
				body: [
					{name: 'Test1'},
					{name: 'Test2'},
				]
			});
		}
		return next.handle(req);
	}
}
