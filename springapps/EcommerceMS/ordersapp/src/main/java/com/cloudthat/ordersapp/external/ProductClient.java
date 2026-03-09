package com.cloudthat.ordersapp.external;

import com.cloudthat.ordersapp.models.ApiResponse;
import org.springframework.cloud.openfeign.FeignClient;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;

import java.util.Optional;

@FeignClient(name = "product-service")
public interface ProductClient {

    @GetMapping("/api/products/{id}")
    ApiResponse<Optional<ProductModel>> getProductById(@PathVariable Long id);
}
