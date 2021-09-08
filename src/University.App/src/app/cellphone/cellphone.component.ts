import { Component, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Cellphone } from '@api';

@Component({
  selector: 'app-cellphone',
  templateUrl: './cellphone.component.html',
  styleUrls: ['./cellphone.component.scss']
})
export class CellphoneComponent {

  constructor(
    @Inject(MAT_DIALOG_DATA) public cellphone: Cellphone
  ) { }

}
