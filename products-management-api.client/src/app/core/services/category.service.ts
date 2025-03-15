// core/services/category.service.ts

import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Category } from "../../../models/category.model";
import { map } from 'rxjs/operators';

@Injectable({ providedIn: 'root' })
export class CategoryService {
  private apiUrl = 'https://localhost:7211/api/category';
  constructor(private http: HttpClient) { }

getAllCategories() {
  return this.http.get<Category[]>(`${this.apiUrl}/getAllCategories`).pipe(
    map(response => response || []) // Handle null responses
  );
}

 

  getCategoryById(id: string) {
    return this.http.get<Category>(`${this.apiUrl}/GetCategoryById/${id}`);
  }

  createCategory(category: Category) {
    return this.http.post(this.apiUrl, category);
  }

  updateCategory(id: string, category: Category) {
    return this.http.put(`${this.apiUrl}/${id}`, category);
  }

  deleteCategory(id: string) {
    return this.http.delete(`${this.apiUrl}/${id}`);
  }
}
