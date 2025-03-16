import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { CategoryFormComponent } from "./categories/category-form/category-form.component";
import { CategoryListComponent } from "./categories/category-list/category-list.component";
import { HomeComponent } from "./home/home.component";
import { ProductFormComponent } from "./products/product-form/product-form.component";
import { ProductListComponent } from "./products/product-list/product-list.component";
import { CategoryProductsComponent } from "./categories/category-products/category-products.component";

export const routes: Routes = [
  { path: "", component: HomeComponent },
  { path: "products", component: ProductListComponent },
  { path: "products/create", component: ProductFormComponent },
  { path: "products/edit/:id", component: ProductFormComponent },
  { path: "categories", component: CategoryListComponent },
  { path: "categories/create", component: CategoryFormComponent },
  { path: "categories/edit/:id", component: CategoryFormComponent },
  {
    path: 'categories/:name/:id',
    component: CategoryProductsComponent
  },
  { path: "**", redirectTo: "/" }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule { }
