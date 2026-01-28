import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { HubConnection, HubConnectionBuilder } from '@microsoft/signalr';
import { BehaviorSubject, Observable } from 'rxjs';

export interface InventoryItem {
  id: number;
  productName: string;
  quantity: number;
  lastUpdated: string;
}

@Injectable({
  providedIn: 'root',
})
export class InventoryService {
  private apiUrl = 'http://localhost:5271/api/inventory';
  private hubUrl = 'http://localhost:5271/hubs/inventory';

  private hubConnection!: HubConnection;

  private inventorySubject = new BehaviorSubject<InventoryItem[]>([]);
  inventory$ = this.inventorySubject.asObservable();

  constructor(private http: HttpClient) {}

  //Fetch Inventory
  fetchInventory() {
    this.http.get<InventoryItem[]>(this.apiUrl).subscribe({
      next: (data) => {
        this.inventorySubject.next(data);
      },
      error: (err) => console.error('API error:', err),
    });
  }

  //Update a stock
  updateStock(id: number, quantity: number): Observable<InventoryItem> {
    return this.http.put<InventoryItem>(`${this.apiUrl}/update?id=${id}&quantity=${quantity}`, {});
  }

  //For SignalR Hub Live Update
  async connectHub() {
    this.hubConnection = new HubConnectionBuilder()
      .withUrl(this.hubUrl)
      .withAutomaticReconnect()
      .build();

    this.hubConnection.on('StockUpdated', (updatedItem: InventoryItem) => {
      const current = this.inventorySubject.value;
      const index = current.findIndex((i) => i.id === updatedItem.id);

      if (index > -1) current[index] = updatedItem;
      else current.push(updatedItem);

      this.inventorySubject.next([...current]);
    });

    await this.hubConnection.start();
  }

  setInventory(data: InventoryItem[]) {
    this.inventorySubject.next(data);
  }
}
