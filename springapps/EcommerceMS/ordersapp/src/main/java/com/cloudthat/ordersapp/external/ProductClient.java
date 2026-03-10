package com.cloudthat.ordersapp.external;

import com.cloudthat.ordersapp.models.ApiResponse;
import io.github.resilience4j.circuitbreaker.CircuitBreaker;
import org.springframework.cloud.openfeign.FeignClient;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;

import java.util.Optional;

@FeignClient(name = "productsapp")
//@CircuitBreaker( name="external", fallbackMethod="fallback")
public interface ProductClient {

    @GetMapping("/api/products/{id}")
    ApiResponse<Optional<ProductModel>> getProductById(@PathVariable Long id);
}
