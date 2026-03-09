package com.cloudthat.ordersapp.services;

import com.cloudthat.ordersapp.models.OrdersModel;

public interface OrdersService {
    OrdersModel create(OrdersModel ordersModel);
}
