package com.example.apigateway.controllers;

import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RestController;

@RestController
public class FallbackController {

    @GetMapping("/ordersappFallBack")
    public String ordersappFallback(){
        return "Order Service is DOWN!";
    }

    @GetMapping("/productsappFallBack")
    public String productsFallback(){
        return "Products Service is DOWN!";
    }
}
