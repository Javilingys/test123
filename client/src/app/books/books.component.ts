import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Book } from './book';
import { map } from 'rxjs/operators';
import { AnyARecord } from 'node:dns';

@Component({
  selector: 'app-books',
  templateUrl: './books.component.html',
  styleUrls: ['./books.component.css']
})
export class BooksComponent implements OnInit {
  books: Book[] = [];
  
  constructor(private httpClient: HttpClient) { }

  ngOnInit(): void {
    this.loadBook();
  }

  loadBook() {
    this.httpClient.get<Book[]>("https://localhost:5001/api/books").subscribe((data) => this.books = data);
  }
}
