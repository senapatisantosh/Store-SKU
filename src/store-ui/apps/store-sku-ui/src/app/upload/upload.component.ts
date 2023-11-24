import { Component, OnDestroy, OnInit, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatTooltipModule } from '@angular/material/tooltip';
import { DragAndDropDirective } from './drag-and-drop.directive';
import { UploadStatus, UploadStore } from './upload.store';
import { UploadService } from './upload.service';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { Subject, filter, takeUntil } from 'rxjs';

@Component({
  selector: 'store-ui-upload',
  standalone: true,
  imports: [
    CommonModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    MatTooltipModule,
    MatIconModule,
    DragAndDropDirective
  ],
  templateUrl: './upload.component.html',
  styleUrls: ['./upload.component.scss'],
  providers: [UploadService, UploadStore],
})
export class UploadComponent implements OnInit, OnDestroy {
  private destroy$ = new Subject<boolean>();
  uploadStore = inject(UploadStore);
  matSnackBar = inject(MatSnackBar);
  files: File[] = [];

  ngOnInit(): void {
    this.uploadStore.statusMessage$
      .pipe(filter(Boolean), takeUntil(this.destroy$))
      .subscribe(message => this.matSnackBar.open(message, "Ok"));
    this.uploadStore.status$
      .pipe(filter(x => x === UploadStatus.Completed), takeUntil(this.destroy$))
      .subscribe(_ => this.files = []);
  }
  reset() {
    this.files = [];
  }

  onFileDropped(files: File[]): void {
    this.files = files;
  }

  fileBrowseHandler($event: Event) {
    let fileList = ($event.target as HTMLInputElement).files;
    if (fileList && fileList.length > 0) {
      let files = Array.from(fileList);
      this.files = files;
    }
  }

  uploadFiles(files: File[]) {
    if (files.length === 0) {
      return;
    }

    let filesToUpload: File[] = files;
    const formData = new FormData();

    Array.from(filesToUpload).map((file, index) => {
      return formData.append('file' + index, file, file.name);
    });

    this.uploadStore.uploadFile(formData);
  }

  ngOnDestroy(): void {
    this.destroy$.next(false);
    this.destroy$.complete()
  }
}
