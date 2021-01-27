import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class PropertiesService {

  constructor(private httpClient: HttpClient) { }

  readAll(): Observable<any> {
    return this.httpClient.get(`${environment.baseURL}/Properties`);
  }

  read(id): Observable<any> {
    return this.httpClient.get(`${environment.baseURL}/Properties/${id}`);
  }

  create(data): Observable<any> {
    return this.httpClient.post(`${environment.baseURL}/Properties`, data);
  }

  update(id, data): Observable<any> {
    return this.httpClient.put(`${environment.baseURL}/Properties/${id}`, data);
  }

  delete(id): Observable<any> {
    return this.httpClient.delete(`${environment.baseURL}/Properties/${id}`);
  }
}
