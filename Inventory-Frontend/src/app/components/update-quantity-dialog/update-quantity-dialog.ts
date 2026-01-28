import { Component, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA, MatDialogModule } from '@angular/material/dialog';
import { InventoryItem } from '../../services/inventory.service';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  standalone: true,
  selector: 'app-update-quantity-dialog',
  imports: [CommonModule, FormsModule, MatDialogModule],
  templateUrl: './update-quantity-dialog.html',
})
export class UpdateQuantityDialog {
  quantity!: number;

  constructor(
    @Inject(MAT_DIALOG_DATA) public data: InventoryItem,
    private dialogRef: MatDialogRef<UpdateQuantityDialog>,
  ) {
    this.quantity = data.quantity;
  }

  onSave() {
    this.dialogRef.close(this.quantity);
  }

  onCancel() {
    this.dialogRef.close();
  }
}
