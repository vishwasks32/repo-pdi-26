package com.cloudthat.productsapp.mappers;

import com.cloudthat.productsapp.entities.Product;
import com.cloudthat.productsapp.models.ProductModel;
import org.mapstruct.Mapper;

@Mapper(componentModel = "spring")
public interface ProductMapper {

    ProductModel toProductModel(Product product);
    Product toProduct(ProductModel productModel);
}
