import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { StudentRoutingModule } from './student-routing.module';
import { StudentComponent } from './student.component';
import { MatCardModule } from '@angular/material/card';
import { MatDialogModule } from '@angular/material/dialog';
import { CellphoneModule } from '../cellphone/cellphone.module';
import { BookModule } from '../book/book.module';
import { PhoneFilterPipe } from './phone-filter.pipe';

@NgModule({
  declarations: [
    StudentComponent,
    PhoneFilterPipe
  ],
  imports: [
    CommonModule,
    StudentRoutingModule,
    MatCardModule,
    MatDialogModule,
    CellphoneModule,
    BookModule
  ]
})
export class StudentModule { }
