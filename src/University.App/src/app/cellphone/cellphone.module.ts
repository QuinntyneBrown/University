import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CellphoneComponent } from './cellphone.component';
import { MatDialogModule } from '@angular/material/dialog';


@NgModule({
  declarations: [
    CellphoneComponent
  ],
  exports: [
    CellphoneComponent
  ],
  imports: [
    CommonModule,
    MatDialogModule
  ]
})
export class CellphoneModule { }
