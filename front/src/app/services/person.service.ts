import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { urlApi } from 'src/environments/environment';
import { Person } from '../models/person';
import { ResponseApi } from '../models/response';

@Injectable({
  providedIn: 'root'
})
export class PersonService {

  private controllerName = "Person"

  constructor(private httpClient: HttpClient) {}

  getAll(){
    return this.httpClient.get<ResponseApi<Person[]>>(`${urlApi}${this.controllerName}`).toPromise()
  }

  put(person: Person){

    return new Promise<ResponseApi<Person[]>>(res => {
      this.deleteById(person.businessEntityID)
      .then(() => {
        this.post(person).then(data => res(data));
      })

    });

   
  }

  post(person: Person){
    return this.httpClient.post<ResponseApi<Person[]>>(`${urlApi}${this.controllerName}`, person).toPromise()
  }

  deleteById(id: number)
  {
    return this.httpClient.delete<void>(`${urlApi}${this.controllerName}/${id}`).toPromise()
  }

}
