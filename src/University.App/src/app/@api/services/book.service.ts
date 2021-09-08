import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Book } from '@api';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { baseUrl, EntityPage, IPagableService } from '@core';

@Injectable({
  providedIn: 'root'
})
export class BookService implements IPagableService<Book> {

  uniqueIdentifierName: string = "bookId";

  constructor(
    @Inject(baseUrl) private readonly _baseUrl: string,
    private readonly _client: HttpClient
  ) { }

  getPage(options: { pageIndex: number; pageSize: number; }): Observable<EntityPage<Book>> {
    return this._client.get<EntityPage<Book>>(`${this._baseUrl}api/book/page/${options.pageSize}/${options.pageIndex}`)
  }

  public get(): Observable<Book[]> {
    return this._client.get<{ books: Book[] }>(`${this._baseUrl}api/book`)
      .pipe(
        map(x => x.books)
      );
  }

  public getById(options: { bookId: string }): Observable<Book> {
    return this._client.get<{ book: Book }>(`${this._baseUrl}api/book/${options.bookId}`)
      .pipe(
        map(x => x.book)
      );
  }

  public remove(options: { book: Book }): Observable<void> {
    return this._client.delete<void>(`${this._baseUrl}api/book/${options.book.bookId}`);
  }

  public create(options: { book: Book }): Observable<{ book: Book }> {
    return this._client.post<{ book: Book }>(`${this._baseUrl}api/book`, { book: options.book });
  }
  
  public update(options: { book: Book }): Observable<{ book: Book }> {
    return this._client.put<{ book: Book }>(`${this._baseUrl}api/book`, { book: options.book });
  }
}
