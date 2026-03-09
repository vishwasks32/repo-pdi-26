package com.cloudthat.productsapp.services;

import com.cloudthat.productsapp.entities.Product;
import com.cloudthat.productsapp.mappers.ProductMapper;
import com.cloudthat.productsapp.models.ProductModel;
import com.cloudthat.productsapp.repositories.ProductRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
public class ProductServiceImpl implements ProductService{

    @Autowired
    private ProductRepository productRepository;

    @Autowired
    private ProductMapper productMapper;

    @Override
    public ProductModel createProduct(ProductModel productModel) {
        Product product = productMapper.toProduct(productModel);
        Product newProduct = productRepository.save(product);

        return productMapper.toProductModel(newProduct);
    }

    @Override
    public List<ProductModel> getAllProducts() {

        List<Product> products = productRepository.findAll();

        List<ProductModel> productModels = products.stream()
                .map(product -> productMapper.toProductModel(product))
                .toList();
        return productModels;
    }
}
