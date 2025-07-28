import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Router, NavigationEnd, RouterLink } from '@angular/router';
import { filter } from 'rxjs/operators';
import { AuthService, User } from '@services/auth';

@Component({
  selector: 'app-navbar',
  standalone: true,
  imports: [CommonModule, RouterLink],
  templateUrl: './navbar.html',
  styleUrls: ['./navbar.scss']
})
export class Navbar implements OnInit {
  public currentRoute: string = '';
  public currentUser: User | null = null;

  constructor(
    private router: Router,
    private authService: AuthService
  ) {
    // Update on every route change, including initial load
    this.router.events
      .pipe(filter(event => event instanceof NavigationEnd))
      .subscribe((event: any) => {
        this.currentRoute = event.urlAfterRedirects;
      });
  }

  ngOnInit() {
    // Subscribe to the auth service's currentUser$ observable
    this.authService.currentUser$.subscribe(user => {
      this.currentUser = user;
    });
  }

  /**
   * Convert numeric role to readable text
   */
  getUserRoleText(roleId: number): string {
    const roles: Record<number, string> = {
      0: 'Admin',
      1: 'Fournisseur',
      2: 'Transitaire',
      3: 'Transporteur',
      4: 'Client'
    };
    return roles[roleId] || 'Utilisateur';
  }

  /**
   * Logout the current user and redirect to home
   */
  logout(): void {
    this.authService.logout();
    this.router.navigate(['/']);
  }
}
