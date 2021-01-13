import { Component, OnInit } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { Person } from './models/person';
import { Phone } from './models/phone';
import { PhoneNumberType } from './models/phoneNumberType';
import { PersonService } from './services/person.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit{

  nameCtrl = new FormControl('', Validators.required)
  celularCtrl = new FormControl('', Validators.required)
  tipoCelular = new FormControl('', Validators.required)

  values: Person[] = []
  personEdit = new Person();

  constructor(private personService: PersonService){
  }

  ngOnInit(): void {
    this.listagem();
  }

  listagem(){
    this.personService.getAll().then(res => {
      
      console.log(res)
      this.values = res.data.personObjects.map(x => new Person(x))
    
    })
    .finally(() => console.log(this.values))
  }

  addPhone(){

    if(this.celularCtrl.invalid || this.tipoCelular.invalid)
      return;

    this.personEdit.phones = [...this.personEdit.phones, 
      new Phone({ 
        businessEntityID: 0, 
        phoneNumber: this.celularCtrl.value, 
        phoneNumberType: new PhoneNumberType({
          businessEntityID : 0, 
          name: this.tipoCelular.value
        }) 
      })]

      this.celularCtrl.setValue('')
      this.tipoCelular.setValue('')

      this.celularCtrl.reset()
      this.tipoCelular.reset()

  }

  remover(id:number){
    this.personService.deleteById(id).then(() => this.listagem())
  }

  addPessoa(){
    
    if(this.nameCtrl.invalid)
      return;

    this.personEdit.name = this.nameCtrl.value

    let promise = null;

    if(this.personEdit.businessEntityID)
      promise = this.personService.put(this.personEdit)
    else
      promise = this.personService.post(this.personEdit)

    promise.finally(() => this.listagem())

    this.nameCtrl.setValue('')
    this.nameCtrl.reset()
  }

}
