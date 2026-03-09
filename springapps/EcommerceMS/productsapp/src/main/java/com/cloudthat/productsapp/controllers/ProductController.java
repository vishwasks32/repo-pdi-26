package com.cloudthat.productsapp.controllers;

import com.cloudthat.productsapp.models.ApiResponse;
import com.cloudthat.productsapp.models.ProductModel;
import com.cloudthat.productsapp.services.ProductService;
import jakarta.persistence.GeneratedValue;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.List;
import java.util.Optional;

@RestController
@RequestMapping("/api/products")
public class ProductController {

    @Autowired
    private ProductService productService;

    @PostMapping
    public ResponseEntity<ApiResponse<ProductModel>> create(@RequestBody ProductModel productModel){

        ProductModel productModel1 = productService.createProduct(productModel);

        return ResponseEntity.status(201)
                .body(new ApiResponse<>(true, "Product Created successfully", productModel1, 0L));
    }

    @GetMapping
    public ResponseEntity<ApiResponse<List<ProductModel>>> getAll(){

        List<ProductModel> productModels = productService.getAllProducts();

        return ResponseEntity.ok(new ApiResponse<>(true,"Products fetchd successfully", productModels,0L));
    }

    @GetMapping("/{id}")
    public ResponseEntity<ApiResponse<Optional<ProductModel>>> getproduct(@PathVariable("id") Long id){

        Optional<ProductModel> productModel = productService.getProduct(id);

        if(productModel.isEmpty()){
            return ResponseEntity.status(404).body(new ApiResponse<>(false,"Products Not Found", null,0L));
        }

        return ResponseEntity.ok(new ApiResponse<>(true,"Products fetchd successfully", productModel,0L));
    }
}
