import { Component } from '@angular/core';
import { CategoryService } from '../../core/services/category.service';
import { Observable } from 'rxjs';
import { Category } from '../../../models/category.model';

@Component({
  selector: 'app-category-list',
  templateUrl: './category-list.component.html',
})
export class CategoryListComponent {
  categories$: Observable<Category[]>;  // Declare without initialization

  constructor(private categoryService: CategoryService) {
    // Initialize after injection
    this.categories$ = this.categoryService.getAllCategories();
  }

  deleteCategory(id: string) {
    if (confirm('Are you sure you want to delete this category?')) {
      this.categoryService.deleteCategory(id).subscribe(() => {
        this.categories$ = this.categoryService.getAllCategories();
      });
    }
  }
}
