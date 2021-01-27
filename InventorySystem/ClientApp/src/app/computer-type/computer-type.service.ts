import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ComputerTypeService {

  constructor(private httpClient: HttpClient) { }

  readAll(): Observable<any> {
    return this.httpClient.get(`${environment.baseURL}/ComputerType`);
  }

  read(id): Observable<any> {
    return this.httpClient.get(`${environment.baseURL}/ComputerType/${id}`);
  }

  create(data): Observable<any> {
    return this.httpClient.post(`${environment.baseURL}/ComputerType`, data);
  }

  update(id, data): Observable<any> {
    return this.httpClient.put(`${environment.baseURL}/ComputerType/${id}`, data);
  }

  delete(id): Observable<any> {
    return this.httpClient.delete(`${environment.baseURL}/ComputerType/${id}`);
  }
}
