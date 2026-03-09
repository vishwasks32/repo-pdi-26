package com.cloudthat.ordersapp.services;

import com.cloudthat.ordersapp.entities.Orders;
import com.cloudthat.ordersapp.external.ProductClient;
import com.cloudthat.ordersapp.external.ProductModel;
import com.cloudthat.ordersapp.mappers.OrdersMapper;
import com.cloudthat.ordersapp.models.ApiResponse;
import com.cloudthat.ordersapp.models.OrdersModel;
import com.cloudthat.ordersapp.repositories.OrdersRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.Optional;

@Service
public class OrdersServiceImpl implements OrdersService {

    @Autowired
    private ProductClient productClient;

    @Autowired
    private OrdersRepository ordersRepository;

    @Autowired
    private OrdersMapper ordersMapper;

    @Override
    public OrdersModel create(OrdersModel ordersModel) {
        // Check if product is present
        ApiResponse<Optional<ProductModel>> apiResponse = productClient.getProductById(ordersModel.getProductId());

        if(!apiResponse.success()) {
            throw new RuntimeException("cannot place order as product is not present");
        }

        Orders order = ordersRepository.save(ordersMapper.toOrders(ordersModel));

        return ordersMapper.toOrdersModel(order);

    }
}
