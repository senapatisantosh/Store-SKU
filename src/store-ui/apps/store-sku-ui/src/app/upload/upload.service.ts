import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";

@Injectable()
export class UploadService {
    private apiUrl = "http://localhost:5000";

    constructor(private httpClient: HttpClient) { }

    uploadFile = (formData: FormData) => 
        this.httpClient.post(`${this.apiUrl}/api/Ingestion/multiple-ingestion`, formData, { reportProgress: true, observe: 'events' })
}