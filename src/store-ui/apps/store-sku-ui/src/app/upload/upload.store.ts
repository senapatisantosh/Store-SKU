import { Injectable, inject } from "@angular/core";
import { ComponentStore } from "@ngrx/component-store";
import { UploadService } from "./upload.service";
import { Observable, catchError, concatMap, of, switchMap, tap } from "rxjs";
import { HttpEvent, HttpEventType } from "@angular/common/http";

export interface UploadState {
    statusMessage: string;
    progress: number;
}

const defaultState = {};

@Injectable()
export class UploadStore extends ComponentStore<UploadState> {
    uploadService = inject(UploadService);
    constructor() {
        super(defaultState as UploadState);
    }

    readonly statusMessage$ = this.select((state) => state.statusMessage);
    readonly progress$ = this.select((state) => state.progress);

    readonly uploadFile = this.effect((formData$: Observable<FormData>) => {
        return formData$.pipe(
            switchMap((formData) => {
                this.patchState({
                    statusMessage: '',
                    progress: 0
                });

                return this.uploadService.uploadFile(formData)
                    .pipe(tap((event: HttpEvent<any>) => { this.updateEventsPeriodically(event) }));
            })
        );
    });

    private updateEventsPeriodically(event: HttpEvent<string>) {
        switch (event.type) {
            case HttpEventType.UploadProgress:
                if (event === null || event === undefined) {
                    return;
                }
                this.patchState({
                    statusMessage: 'Uploading ...',
                    progress: Math.round((100 * event.loaded) / event.total!),
                });
                break;
            case HttpEventType.Response:
                this.patchState({
                    statusMessage: 'Upload complete.',
                    progress: 100,
                });
                break;
            default:
                break;
        }
    }
}