import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BookComponent } from './book.component';
import { MatDialogModule } from '@angular/material/dialog';



@NgModule({
  declarations: [
    BookComponent
  ],
  exports: [
    BookComponent
  ],
  imports: [
    CommonModule,
    MatDialogModule
  ]
})
export class BookModule { }
