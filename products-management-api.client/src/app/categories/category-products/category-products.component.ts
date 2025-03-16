// categories/category-products/category-products.component.ts
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ProductService } from '../../core/services/product.service';
import { CategoryService } from '../../core/services/category.service';
import { Product } from '../../../models/product.model';
import { Category } from '../../../models/category.model';

@Component({
  selector: 'app-category-products',
  templateUrl: './category-products.component.html'
})
export class CategoryProductsComponent implements OnInit {
  products: Product[] = [];
  category!: Category;
  isLoading = true;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private productService: ProductService,
    private categoryService: CategoryService
  ) { }

  ngOnInit(): void {
    this.route.paramMap.subscribe(params => {
      const categoryId = params.get('id');
      const categoryName = params.get('name');

      if (categoryId) {
        this.loadCategoryDetails(categoryId);
        this.loadProducts(categoryId);
      }
    });
  }

  private loadCategoryDetails(categoryId: string): void {
    this.categoryService.getCategoryById(categoryId).subscribe({
      next: (category) => this.category = category,
      error: () => this.router.navigate(['/categories'])
    });
  }

  private loadProducts(categoryId: string): void {
    this.productService.getProductsByCategory(categoryId).subscribe({
      next: (products) => {
        this.products = products;
        this.isLoading = false;
      },
      error: () => this.isLoading = false
    });
  }

  deleteProduct(productId: string): void {
    if (confirm('Are you sure you want to delete this product?')) {
      this.productService.deleteProduct(productId).subscribe({
        next: () => this.loadProducts(this.category.id),
        error: () => alert('Failed to delete product')
      });
    }
  }
}
