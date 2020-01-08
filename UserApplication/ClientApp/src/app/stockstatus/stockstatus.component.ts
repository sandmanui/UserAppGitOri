import { Component, OnInit, Input, Output, EventEmitter, OnChanges, SimpleChanges } from '@angular/core';

@Component({
  selector: 'app-stockstatus',
  //templateUrl: './stockstatus.component.html',
  template: `<input type='number' [(ngModel)]='updatedstockvalue'/> <button class='btn btn-primary'
     [style.background]='color'
     (click)="stockValueChanged()">Change Stock Value</button> `,
  styleUrls: ['./stockstatus.component.css']
})
export class StockStatusComponent implements OnChanges {

  @Input() stock: number;
  @Input() productId: number;
  @Output() stockValueChange = new EventEmitter();
  public color: string = '';
  updatedstockvalue: number; 
  stockValueChanged() {

    this.stockValueChange.emit({id:this.productId, updatedstockvalue:this.updatedstockvalue});
    this.updatedstockvalue = null;
  }
  ngOnChanges(changes: SimpleChanges): void {
    if (this.stock > 10) {
      this.color = 'green';
    } else {
      this.color = 'red';
    }
  }
}
