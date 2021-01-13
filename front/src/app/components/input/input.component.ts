import { Component, Inject, Input, OnInit } from '@angular/core';
import { AbstractControl, FormControl, FormGroupDirective, NgForm } from '@angular/forms';
import { ErrorStateMatcher } from '@angular/material/core';

@Component({
  selector: 'app-input',
  templateUrl: './input.component.html',
  styleUrls: ['./input.component.scss']
})
export class InputComponent implements OnInit {

  @Input()
  label: string

  @Input()
  type: 'text' | 'email' | 'date' = 'text';

  @Input()
  formCtrl: AbstractControl

  @Input()
  mask: string

  @Input()
  readonly: boolean

  // Usado para somente deixar os campos "Danger" quando são interagidos.
  matcher = new ErrorStateMatcher()

  constructor() { }

  ngOnInit(): void {
  }

}
