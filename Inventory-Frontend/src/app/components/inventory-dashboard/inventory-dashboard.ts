import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatDialog, MatDialogModule } from '@angular/material/dialog';
import { InventoryService, InventoryItem } from '../../services/inventory.service';
import { UpdateQuantityDialog } from '../update-quantity-dialog/update-quantity-dialog';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-inventory-dashboard',
  standalone: true,
  imports: [CommonModule, MatDialogModule],
  templateUrl: './inventory-dashboard.html',
  styleUrls: ['./inventory-dashboard.css'],
})
export class InventoryDashboard implements OnInit {
  inventory$!: Observable<InventoryItem[]>;

  constructor(
    private inventoryService: InventoryService,
    private dialog: MatDialog,
  ) {}

  ngOnInit(): void {
    this.inventoryService.connectHub();
    this.inventoryService.fetchInventory();
    this.inventory$ = this.inventoryService.inventory$;
  }

  openUpdateDialog(item: InventoryItem) {
    const dialogRef = this.dialog.open(UpdateQuantityDialog, {
      width: '300px',
      data: item,
    });

    dialogRef.afterClosed().subscribe((result) => {
      if (result !== undefined) {
        this.inventoryService.updateStock(item.id, result).subscribe({
          next: (updatedItem: InventoryItem) => {
            //console.log('Item updated on backend:', updatedItem);
          },
          error: (err: any) => console.error('Update failed', err),
        });
      }
    });
  }
}
