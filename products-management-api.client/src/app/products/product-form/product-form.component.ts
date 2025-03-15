import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ProductService } from '../../core/services/product.service';
import { CategoryService } from '../../core/services/category.service';
import { Product } from '../../../models/product.model';
import { Category } from '../../../models/category.model';

@Component({
  selector: 'app-product-form',
  templateUrl: './product-form.component.html',
})
export class ProductFormComponent implements OnInit {
  productForm: FormGroup;
  categories: Category[] = [];
  productId?: string;
  isEditMode = false;

  constructor(
    private fb: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private productService: ProductService,
    private categoryService: CategoryService
  ) {
    this.productForm = this.fb.group({
      name: ['', Validators.required],
      value: ['', [Validators.required, Validators.min(0)]],
      currency: ['USD', Validators.required],
      categoryId: ['', Validators.required]
    });
  }

  ngOnInit(): void {
    this.productId = this.route.snapshot.params['id'];
    this.isEditMode = !!this.productId;

    this.categoryService.getAllCategories().subscribe(categories => {
      this.categories = categories;
    });

    if (this.isEditMode) {
      this.productService.getProductById(this.productId!).subscribe(product => {
        this.productForm.patchValue({
          name: product.name,
          value: product.price.value,
          currency: product.price.currency,
          categoryId: product.categoryId
        });
      });
    }
  }

  onSubmit() {
    if (this.productForm.invalid) return;

    const productData: Product = {
      id: this.productId || '',
      name: this.productForm.value.name,
      price: {
        value: this.productForm.value.value,
        currency: this.productForm.value.currency
      },
      categoryId: this.productForm.value.categoryId
    };

    const operation = this.isEditMode
      ? this.productService.updateProduct(this.productId!, productData)
      : this.productService.createProduct(productData);

    operation.subscribe(() => {
      this.router.navigate(['/products']);
    });
  }
}
