import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatInputModule } from '@angular/material/input';

import { ComponentsRoutingModule } from './components-routing.module';
import { TitleComponent } from './title/title.component';
import { InputComponent } from './input/input.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgxMaskModule } from 'ngx-mask';
import { ButtonComponent } from './button/button.component';




@NgModule({
  declarations: [TitleComponent, InputComponent, ButtonComponent],
  imports: [
    FormsModule,
    ReactiveFormsModule,
    CommonModule,
    ComponentsRoutingModule,
    MatInputModule,
    NgxMaskModule.forRoot()
  ],
  exports: [TitleComponent, InputComponent, ButtonComponent]
})
export class ComponentsModule { }
