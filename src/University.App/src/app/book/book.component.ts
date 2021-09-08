import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Book } from '@api';

@Component({
  selector: 'app-book',
  templateUrl: './book.component.html',
  styleUrls: ['./book.component.scss']
})
export class BookComponent  {
  constructor(
    @Inject(MAT_DIALOG_DATA) public book: Book
  ) { }
}
