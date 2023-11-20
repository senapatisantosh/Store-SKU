import { Route } from '@angular/router';
import { UploadComponent } from './upload/upload.component';

export const appRoutes: Route[] = [
    {
        path: '',
        redirectTo: 'upload',
        pathMatch: 'full'
    },
    {
        path: 'upload',
        component: UploadComponent
    },
    {
        path: '**',
        redirectTo: 'upload'
    },
];
