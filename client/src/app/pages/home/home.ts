import { Component, OnInit, AfterViewInit } from '@angular/core';
import { Router } from '@angular/router';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './home.html',
  styleUrls: ['./home.scss']
})
export class Home implements OnInit, AfterViewInit {

  constructor(private router: Router) {}

  ngOnInit(): void {
    // Initialization logic
  }

  ngAfterViewInit(): void {
    // Animate count-up for statistics
    this.animateCountUp();
  }

  navigateToRegister(): void {
    this.router.navigate(['/register']);
  }

  openDemoVideo(): void {
    // Could open a modal or navigate to a demo page
    window.open('https://example.com/demo', '_blank');
  }

  contactSales(): void {
    this.router.navigate(['/contact']);
  }

  private animateCountUp(): void {
    const countElements = document.querySelectorAll('[data-count]');

    countElements.forEach(element => {
      const target = parseInt(element.getAttribute('data-count') || '0', 10);
      const duration = 2000; // milliseconds
      const startTime = Date.now();
      let currentNumber = 0;

      const updateCounter = () => {
        const elapsedTime = Date.now() - startTime;
        if (elapsedTime > duration) {
          element.textContent = target.toString();
          return;
        }

        const progress = elapsedTime / duration;
        currentNumber = Math.floor(progress * target);
        element.textContent = currentNumber.toString();

        // Use percentage symbol for the second stat
        if (element.parentElement?.querySelector('p')?.textContent?.includes('Time Saved')) {
          element.textContent += '%';
        }

        // Add "+" for shipments
        if (element.parentElement?.querySelector('p')?.textContent?.includes('Shipments')) {
          element.textContent += '+';
        }

        requestAnimationFrame(updateCounter);
      };

      requestAnimationFrame(updateCounter);
    });
  }
}
