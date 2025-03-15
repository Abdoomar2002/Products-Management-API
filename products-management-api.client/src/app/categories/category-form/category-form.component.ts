import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { CategoryService } from '../../core/services/category.service';
import { Category } from '../../../models/category.model';

@Component({
  selector: 'app-category-form',
  templateUrl: './category-form.component.html',
})
export class CategoryFormComponent implements OnInit {
  categoryForm: FormGroup;
  categoryId?: string;
  isEditMode = false;

  constructor(
    private fb: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private categoryService: CategoryService
  ) {
    this.categoryForm = this.fb.group({
      name: ['', Validators.required],
      productCount: [0, [Validators.required, Validators.min(0)]]
    });
  }

  ngOnInit(): void {
    this.categoryId = this.route.snapshot.params['id'];
    this.isEditMode = !!this.categoryId;

    if (this.isEditMode) {
      this.categoryService.getCategoryById(this.categoryId!).subscribe(category => {
        this.categoryForm.patchValue(category);
      });
    }
  }

  onSubmit() {
    if (this.categoryForm.invalid) return;

    const categoryData: Category = {
      id: this.categoryId || '',
      ...this.categoryForm.value
    };

    const operation = this.isEditMode
      ? this.categoryService.updateCategory(this.categoryId!, categoryData)
      : this.categoryService.createCategory(categoryData);

    operation.subscribe(() => {
      this.router.navigate(['/categories']);
    });
  }
}
