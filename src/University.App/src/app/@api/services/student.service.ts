import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Student } from '@api';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { baseUrl, EntityPage, IPagableService } from '@core';

@Injectable({
  providedIn: 'root'
})
export class StudentService implements IPagableService<Student> {

  uniqueIdentifierName: string = "studentId";

  constructor(
    @Inject(baseUrl) private readonly _baseUrl: string,
    private readonly _client: HttpClient
  ) { }

  getPage(options: { pageIndex: number; pageSize: number; }): Observable<EntityPage<Student>> {
    return this._client.get<EntityPage<Student>>(`${this._baseUrl}api/student/page/${options.pageSize}/${options.pageIndex}`)
  }

  public get(): Observable<Student[]> {
    return this._client.get<{ students: Student[] }>(`${this._baseUrl}api/student`)
      .pipe(
        map(x => x.students)
      );
  }

  public getById(options: { studentId: string }): Observable<Student> {
    return this._client.get<{ student: Student }>(`${this._baseUrl}api/student/${options.studentId}`)
      .pipe(
        map(x => x.student)
      );
  }

  public remove(options: { student: Student }): Observable<void> {
    return this._client.delete<void>(`${this._baseUrl}api/student/${options.student.studentId}`);
  }

  public create(options: { student: Student }): Observable<{ student: Student }> {
    return this._client.post<{ student: Student }>(`${this._baseUrl}api/student`, { student: options.student });
  }
  
  public update(options: { student: Student }): Observable<{ student: Student }> {
    return this._client.put<{ student: Student }>(`${this._baseUrl}api/student`, { student: options.student });
  }
}
