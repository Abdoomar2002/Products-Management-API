// core/services/product.service.ts
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Product } from '../../../models/product.model';
@Injectable({ providedIn: 'root' })
export class ProductService {
  private apiUrl = 'https://localhost:7211/api/product';

  constructor(private http: HttpClient) { }

  getAllProducts() {
    return this.http.get<Product[]>(`${this.apiUrl}/GetAllProducts`);
  }

  getProductById(id: string) {
    return this.http.get<Product>(`${this.apiUrl}/GetProductById/${id}`);
  }

  createProduct(product: Product) {
    return this.http.post(this.apiUrl, product);
  }

  updateProduct(id: string, product: Product) {
    return this.http.put(`${this.apiUrl}/${id}`, product);
  }

  deleteProduct(id: string) {
    return this.http.delete(`${this.apiUrl}/${id}`);
  }

  getProductsByCategory(categoryId: string) {
    return this.http.get<Product[]>(`${this.apiUrl}/GetProductsByCategory/${categoryId}`);
  }
}
