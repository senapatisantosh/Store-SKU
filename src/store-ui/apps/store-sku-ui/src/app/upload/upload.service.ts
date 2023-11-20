import { Injectable } from "@angular/core";
import { HttpClient, HttpEventType } from "@angular/common/http";
import { Subject, tap } from "rxjs";

@Injectable()
export class UploadService {
    private apiUrl = "https://localhost:5000";
    private uploadProgressSubject = new Subject<number>();
    private uploadMessageSubject = new Subject<string>();

    public uploadProgress$ = this.uploadProgressSubject.asObservable();
    public uploadMessage$ = this.uploadMessageSubject.asObservable();

    constructor(private httpClient: HttpClient) { }

    uploadFile(formData: FormData) {
        return this.httpClient.post(`${this.apiUrl}/multple-ingestion`, formData, { reportProgress: true, observe: 'events' })
            .pipe(
                tap((event: any) => {
                    if (event.type === HttpEventType.UploadProgress) {
                        const progress = Math.round(100 * event.loaded / event.total);
                        this.uploadProgressSubject.next(progress);
                    } else if (event.type === HttpEventType.Response) {
                        this.uploadMessageSubject.next('Upload success.');
                        this.uploadMessageSubject.next(event.body);
                    }
                }),
            )
    }
}