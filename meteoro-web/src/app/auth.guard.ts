import { inject } from '@angular/core';
import { Router, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { KeycloakService } from 'keycloak-angular';

export const authGuard = async (route: ActivatedRouteSnapshot, state: RouterStateSnapshot) => {
  const keycloak = inject(KeycloakService);
  const router = inject(Router);

  if (!keycloak.isLoggedIn()) {
    await keycloak.login({
      redirectUri: window.location.origin + state.url
    });
    return false;
  }

  // Opcional: Verificar roles (ej. solo ADMIN puede entrar a ciertas rutas)
  const requiredRoles = route.data['roles'];
  if (requiredRoles && !requiredRoles.every((role: string) => keycloak.getUserRoles().includes(role))) {
    router.navigate(['/']); // O a una página de "Acceso Denegado"
    return false;
  }

  return true;
};