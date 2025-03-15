export interface Product {
  id: string;
  name: string;
  price: Price;
  categoryId: string;
}

export interface Price {
  value: number;
  currency: string;
}
