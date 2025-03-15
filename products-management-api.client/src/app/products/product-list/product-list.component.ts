import { Component, OnInit } from '@angular/core';
import { ProductService } from '../../core/services/product.service';
import { CategoryService } from '../../core/services/category.service';
import { Product } from '../../../models/product.model';
import { Category } from '../../../models/category.model';
import { combineLatest, Observable } from 'rxjs';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
})
export class ProductListComponent implements OnInit {
  products$: Observable<Product[]>;
  categories$: Observable<Category[]>;
  combined$: Observable<[Product[], Category[]]>;
  constructor(
    private productService: ProductService,
    private categoryService: CategoryService
  ) {
   this.products$ = this.productService.getAllProducts();
   this. categories$ = this.categoryService.getAllCategories();
  this. combined$ = combineLatest([this.products$, this.categories$]);

  }


  ngOnInit(): void { }

  deleteProduct(id: string) {
    if (confirm('Are you sure you want to delete this product?')) {
      this.productService.deleteProduct(id).subscribe(() => {
        this.products$ = this.productService.getAllProducts();
      });
    }
  }

  getCategoryName(categoryId: string, categories: Category[]): string {
    return categories.find(c => c.id === categoryId)?.name || 'Unknown';
  }
}
