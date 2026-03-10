package com.cloudthat.paymentsapp.services;

import com.cloudthat.paymentsapp.entities.OrderEvent;

public interface PaymentService {
    void processOrderPayment(OrderEvent event);
}
