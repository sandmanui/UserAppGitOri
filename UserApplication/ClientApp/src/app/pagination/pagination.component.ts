import { Component, OnInit, OnChanges, Input, Output, EventEmitter, SimpleChanges } from '@angular/core';
//import { EventEmitter } from 'protractor';
import * as _ from "lodash";

@Component({
  selector: 'app-pagination-comp',
  templateUrl: './pagination.component.html',
  styleUrls: ['./pagination.component.css']
})
export class PaginationComponent implements OnInit, OnChanges {
  @Input('dataSet') dataSet: Array<any>;
  @Input('pageSize') pageSize: number;
  @Output('getPageResult') getPageResult: EventEmitter<any>;
  pageResult: Array<any>;
  paginationLength: Array<number>;
  currentPageIndex: number;


  ngOnChanges(changes: SimpleChanges): void {
    this.paginationLength = new Array<number>();
    this.setPaginationlength();
    this.setPageResults(0);
  }

  constructor() { 
    this.getPageResult = new EventEmitter<any>();
  }

  ngOnInit() {
  }

  setPaginationlength(): void {
    for (let index = 0; index < (this.dataSet.length / this.pageSize); index++) {
      this.paginationLength.push(index);
    }
  }

  setPageResults(pageIndex: number): void {
    if (this.dataSet !== undefined && this.dataSet.length !== 0 && pageIndex >= 0 && pageIndex<this.paginationLength.length) {
      this.currentPageIndex = pageIndex;
      let clients = _.cloneDeep(this.dataSet);
      this.pageResult = clients.splice((this.pageSize * this.currentPageIndex),this.pageSize);
      this.getPageResult.emit(this.pageResult);
    }
  }

}
