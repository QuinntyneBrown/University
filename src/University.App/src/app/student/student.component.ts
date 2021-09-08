import { Component, OnDestroy } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ActivatedRoute } from '@angular/router';
import { Book, Cellphone, CellphoneService, StudentService } from '@api';
import { combineLatest, of, Subject } from 'rxjs';
import { map, switchMap, takeUntil } from 'rxjs/operators';
import { BookComponent } from '../book/book.component';
import { CellphoneComponent } from '../cellphone/cellphone.component';

@Component({
  selector: 'app-student',
  templateUrl: './student.component.html',
  styleUrls: ['./student.component.scss']
})
export class StudentComponent implements OnDestroy {

  protected readonly _destroyed = new Subject();

  public vm$ = this._activatedRoute
  .paramMap
  .pipe(
    map(paramMap => paramMap.get("id")),
    switchMap(phoneId => {
      let cellphone$ = phoneId ? this._cellphoneService.getById({ cellphoneId: phoneId }) : of(null);

      return combineLatest([
        this._studentService.get(),
        cellphone$
      ])
    }),
    map(([students, cellphone]) => ({ cellphone, students }))
  );

  constructor(
    private readonly _studentService: StudentService,
    private readonly _cellphoneService: CellphoneService,
    private readonly _dialog: MatDialog,
    private readonly _activatedRoute: ActivatedRoute
  ) {

  }

  public openCellphoneDialog(cellphone: Cellphone) {
    this._dialog.open<CellphoneComponent>(CellphoneComponent, {
      data: cellphone
    })
    .afterClosed()
    .pipe(
      takeUntil(this._destroyed)
    )
    .subscribe();
  }

  public openBookDialog(book: Book) {
    this._dialog.open<BookComponent>(BookComponent, {
      data: book
    })
    .afterClosed()
    .pipe(
      takeUntil(this._destroyed)
    )
    .subscribe();
  }

  ngOnDestroy() {
    this._destroyed.next();
    this._destroyed.complete();
  }
}
