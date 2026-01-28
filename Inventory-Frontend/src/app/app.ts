import { Component, signal } from '@angular/core';
import { InventoryDashboard } from './components/inventory-dashboard/inventory-dashboard';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [InventoryDashboard],
  templateUrl: './app.html',
  styleUrl: './app.css',
})
export class App {
  protected readonly title = signal('Inventory-Frontend');
}
