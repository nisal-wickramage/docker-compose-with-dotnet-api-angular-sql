import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  url: string;

  constructor(private httpClient: HttpClient) {
    this.url = 'http://localhost:5000/product';
  }

  getProducts(): Observable<Product[]> {
    return this.httpClient.get<any[]>(this.url).pipe(map(products => {
      return products.map(p => {
        return new Product(p.name, p.price);
      });
    }));
  }
}

export class Product
{
  constructor(name: string, price: number) {
    this.Name = name;
    this.Price = price;
  }
  Name: string;
  Price: number;
}
