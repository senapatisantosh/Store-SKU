import { Directive, EventEmitter, HostBinding, HostListener, Output } from '@angular/core';

@Directive({
  selector: '[storeUiDragAndDrop]',
  standalone: true,
})
export class DragAndDropDirective {
  @HostBinding('class.fileover') fileOver!: boolean;
  @Output() fileDropped: EventEmitter<File[]> = new EventEmitter();

  constructor() {}

  // Dragover listener
  @HostListener('dragover', ['$event']) onDragOver(event: DragEvent) {
    event.preventDefault();
    event.stopPropagation();
    this.fileOver = true;
  }

  // Dragleave listener
  @HostListener('dragleave', ['$event']) public onDragLeave(event: DragEvent) {
    event.preventDefault();
    event.stopPropagation();
    this.fileOver = false;
  }

  // Drop listener
  @HostListener('drop', ['$event']) public ondrop(event: DragEvent) {
    event.preventDefault();
    event.stopPropagation();
    this.fileOver = false;
    let files: File[] = [];
    for (let i = 0; i < event.dataTransfer!.files.length; i++) {
      const file = event.dataTransfer!.files[i];
      files.push(file);
    }
    if (files.length > 0) {
      this.fileDropped.emit(files);
    }
  }
}
