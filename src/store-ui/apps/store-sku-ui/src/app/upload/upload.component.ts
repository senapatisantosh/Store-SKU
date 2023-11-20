import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatTooltipModule } from '@angular/material/tooltip';
import { DragAndDropDirective } from './drag-and-drop.directive';

@Component({
  selector: 'store-ui-upload',
  standalone: true,
  imports: [CommonModule, MatButtonModule, MatTooltipModule, MatIconModule, DragAndDropDirective],
  templateUrl: './upload.component.html',
  styleUrls: ['./upload.component.scss'],
})
export class UploadComponent {

  files: File[] = [];

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

    formData.forEach(console.log);
  }



}
