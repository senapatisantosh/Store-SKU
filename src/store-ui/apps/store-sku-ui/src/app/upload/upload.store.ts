import { Injectable, inject } from "@angular/core";
import { ComponentStore } from "@ngrx/component-store";
import { UploadService } from "./upload.service";
import { Observable, catchError, concatMap, of, switchMap, tap } from "rxjs";

export interface UploadState {
    progress: number;
    statusMessage: string;
}

const defaultState: UploadState = {
    progress: 0,
    statusMessage: ''
};

@Injectable()
export class UploadStore extends ComponentStore<UploadState> {
    uploadService = inject(UploadService);
    constructor() {
        super(defaultState);
    }

    readonly progress$ = this.select((state) => state.progress);
    readonly statusMessage$ = this.select((state) => state.statusMessage);

    readonly setProgress = this.updater((state, progress: number) => ({ ...state, progress }));
    readonly setStatusMessage = this.updater((state, statusMessage: string) => ({ ...state, statusMessage }));

    readonly uploadFile = this.effect((formData$: Observable<FormData>) => {
        return formData$.pipe(
            switchMap((formData) => {
                this.setProgress(0);
                this.setStatusMessage('');

                return this.uploadService.uploadFile(formData)
                    .pipe(
                        tap((response) => {
                            this.setProgress(100);
                            this.setStatusMessage('Upload success.');
                        }),
                        catchError((error) => {
                            this.setStatusMessage('Upload failed.');
                            return of(error);
                        })
                    );
            })
        );
    });
}