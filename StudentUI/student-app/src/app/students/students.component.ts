import { StudentsService } from './students.service';
import {Component, OnInit, ViewChild} from '@angular/core';
import {MatPaginator, MatTableDataSource} from '@angular/material';

@Component({
// tslint:disable-next-line: component-selector
  selector: 'students-list',
  styleUrls: ['students.component.css'],
  templateUrl: 'students.component.html',
})
export class StudentsComponent implements OnInit {
  displayedColumns: string[] = ['name', 'phoneNumber'];
  dataSource;

  @ViewChild(MatPaginator) paginator: MatPaginator;

  constructor(private service: StudentsService) { }

  ngOnInit() {
    this.service.getStudents()
    .subscribe(response => {
      this.dataSource = new MatTableDataSource<Student>(response.json());
      this.dataSource.paginator = this.paginator;
    });
  }
}

export interface Student {
  name: string;
  phoneNumber: number;
}
