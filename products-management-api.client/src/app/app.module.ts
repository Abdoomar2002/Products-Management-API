import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { ReactiveFormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ProductListComponent } from './products/product-list/product-list.component';
import { HomeComponent } from './home/home.component';
import { ProductFormComponent } from './products/product-form/product-form.component';
import { CategoryListComponent } from './categories/category-list/category-list.component';
import { CategoryFormComponent } from './categories/category-form/category-form.component';
import { NavigationComponent } from './navigation/navigation/navigation.component';
import { routes } from './app-routing.module';
import { CategoryProductsComponent } from './categories/category-products/category-products.component';

@NgModule({
  declarations: [
    ProductListComponent,
    HomeComponent,
    ProductFormComponent,
    CategoryListComponent,
    CategoryFormComponent,
    NavigationComponent,
    AppComponent,
    CategoryProductsComponent
  ],
  imports: [
    BrowserModule,
    ReactiveFormsModule,
    HttpClientModule,
    RouterModule,
    FormsModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})

export class AppModule { }
