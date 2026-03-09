package com.cloudthat.ordersapp.mappers;

import com.cloudthat.ordersapp.entities.Orders;
import com.cloudthat.ordersapp.models.OrdersModel;
import org.mapstruct.Mapper;

@Mapper(componentModel = "spring")
public interface OrdersMapper {

    Orders toOrders(OrdersModel ordersModel);
    OrdersModel toOrdersModel(Orders orders);
}
