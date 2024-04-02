import { HttpClient } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import { IEmployee } from './interfaces/employee';

@Injectable({
  providedIn: 'root',
})
export class HttpService {
  apiUrl = 'https://localhost:7209';
  http = inject(HttpClient);
  constructor() {}

  getAllEmployee() {
    console.log('getAllEmployee', localStorage.getItem('token'));
    return this.http.get<IEmployee[]>(this.apiUrl + '/api/employee');
  }
  createEmployee(employee: IEmployee) {
    return this.http.post(this.apiUrl + '/api/employee', employee);
  }
  getEmployee(employeeId: number) {
    return this.http.get<IEmployee>(
      this.apiUrl + '/api/employee/' + employeeId
    );
  }
  updateEmployee(employeeId: number, employee: IEmployee) {
    return this.http.put<IEmployee>(
      this.apiUrl + '/api/employee/' + employeeId,
      employee
    );
  }
  deleteEmployee(employeeId: number) {
    return this.http.delete(this.apiUrl + '/api/employee/' + employeeId);
  }
  login(email: string, password: string) {
    return this.http.post<{ token: string }>(this.apiUrl + '/api/Auth/login', {
      email: email,
      password: password,
    });
  }
  googleLogin(idToken: string) {
    return this.http.post<{ token: string }>(
      this.apiUrl + '/api/Auth/google-login',
      {
        idToken: idToken,
      }
    );
  }
}
