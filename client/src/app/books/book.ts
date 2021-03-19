export interface Book {
    id: number;
    name: string;
    author: string;
    article: string;
    publishingYear: number;
    count: number;
    readers: Reader[];
  }

export interface Reader {
    id: number;
    firstName: string;
    lastName: string;
    middleName: string;
    dateOfBirth: string;
    books: null[];
  }