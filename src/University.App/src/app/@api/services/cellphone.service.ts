import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Cellphone } from '@api';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { baseUrl, EntityPage, IPagableService } from '@core';

@Injectable({
  providedIn: 'root'
})
export class CellphoneService implements IPagableService<Cellphone> {

  uniqueIdentifierName: string = "cellphoneId";

  constructor(
    @Inject(baseUrl) private readonly _baseUrl: string,
    private readonly _client: HttpClient
  ) { }

  getPage(options: { pageIndex: number; pageSize: number; }): Observable<EntityPage<Cellphone>> {
    return this._client.get<EntityPage<Cellphone>>(`${this._baseUrl}api/cellphone/page/${options.pageSize}/${options.pageIndex}`)
  }

  public get(): Observable<Cellphone[]> {
    return this._client.get<{ cellphones: Cellphone[] }>(`${this._baseUrl}api/cellphone`)
      .pipe(
        map(x => x.cellphones)
      );
  }

  public getById(options: { cellphoneId: string }): Observable<Cellphone> {
    return this._client.get<{ cellphone: Cellphone }>(`${this._baseUrl}api/cellphone/${options.cellphoneId}`)
      .pipe(
        map(x => x.cellphone)
      );
  }

  public remove(options: { cellphone: Cellphone }): Observable<void> {
    return this._client.delete<void>(`${this._baseUrl}api/cellphone/${options.cellphone.cellphoneId}`);
  }

  public create(options: { cellphone: Cellphone }): Observable<{ cellphone: Cellphone }> {
    return this._client.post<{ cellphone: Cellphone }>(`${this._baseUrl}api/cellphone`, { cellphone: options.cellphone });
  }
  
  public update(options: { cellphone: Cellphone }): Observable<{ cellphone: Cellphone }> {
    return this._client.put<{ cellphone: Cellphone }>(`${this._baseUrl}api/cellphone`, { cellphone: options.cellphone });
  }
}
