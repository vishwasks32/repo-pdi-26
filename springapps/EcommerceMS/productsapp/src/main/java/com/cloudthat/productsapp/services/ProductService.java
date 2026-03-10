package com.cloudthat.productsapp.services;

import com.cloudthat.productsapp.models.ProductModel;

import java.util.List;
import java.util.Optional;

public interface ProductService {
    ProductModel createProduct(ProductModel productModel);

    List<ProductModel> getAllProducts();

    ProductModel getProduct(Long id);
}
