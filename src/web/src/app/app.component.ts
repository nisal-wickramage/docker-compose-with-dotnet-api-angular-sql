import { Component, OnInit } from '@angular/core';
import { ProductService } from './product-service.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent  implements OnInit {

  constructor(private productService: ProductService) {
  }

  ngOnInit() {
    this.productService.getProducts().subscribe(data => this.products = data);
  }

  title = 'web';
  products = [{ Name: 'Bread', Price: 2}, { Name: 'Milk', Price: 3}];
}
