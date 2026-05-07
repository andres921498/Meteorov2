import { Routes } from '@angular/router';
import { authGuard } from './auth.guard';

export const routes: Routes = [
  {
    path: 'dashboard',
    // Cargamos el componente App que ya tienes creado en app.ts
    loadComponent: () => import('./app').then(m => m.App),
    canActivate: [authGuard],
    data: { roles: ['ADMIN'] } 
  },
  { 
    path: '', 
    redirectTo: 'dashboard', 
    pathMatch: 'full' 
  }
];