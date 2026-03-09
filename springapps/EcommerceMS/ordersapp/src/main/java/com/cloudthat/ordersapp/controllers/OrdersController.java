package com.cloudthat.ordersapp.controllers;

import com.cloudthat.ordersapp.external.ProductClient;
import com.cloudthat.ordersapp.external.ProductModel;
import com.cloudthat.ordersapp.models.ApiResponse;
import com.cloudthat.ordersapp.models.OrdersModel;
import com.cloudthat.ordersapp.services.OrdersService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import java.util.Optional;

@RestController
@RequestMapping("/api/orders")
public class OrdersController {

    @Autowired
    private OrdersService ordersService;

    @PostMapping("/placeorder")
    public ResponseEntity<ApiResponse<OrdersModel>> placeOrder(@RequestBody OrdersModel ordersModel){

        OrdersModel ordersModel1 = ordersService.create(ordersModel);

        return ResponseEntity.status(201).body(
                new ApiResponse<>(true, "Order Placed successfully", ordersModel1, 0L)
        );

    }
}
