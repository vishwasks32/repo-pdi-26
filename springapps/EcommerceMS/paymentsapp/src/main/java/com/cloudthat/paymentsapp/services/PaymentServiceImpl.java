package com.cloudthat.paymentsapp.services;

import com.cloudthat.paymentsapp.entities.OrderEvent;
import com.cloudthat.paymentsapp.entities.Payment;
import com.cloudthat.paymentsapp.repositories.PaymentRepository;
import lombok.extern.slf4j.Slf4j;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

@Service
@Slf4j
public class PaymentServiceImpl implements PaymentService{

    private static final Logger log = LoggerFactory.getLogger(PaymentServiceImpl.class);
    @Autowired
    private PaymentRepository paymentRepository;

    @Override
    public void processOrderPayment(OrderEvent orderEvent) {
        // 1. Log the incoming event
        log.info("Processing payment for Order ID: {}", orderEvent.getOrderId());
        System.out.println();

        // 2. Business Logic (e.g., check balance, validate amount)
        Payment payment = new Payment();
        payment.setOrderId(orderEvent.getOrderId());
        payment.setAmount(orderEvent.getAmount());

        // Logic: For this demo, let's say payments > 1000 fail
        if (orderEvent.getAmount() > 1000) {
            payment.setPaymentStatus("FAILED");
        } else {
            payment.setPaymentStatus("SUCCESSFUL");
        }

        // 3. Save to Payment Database
        paymentRepository.save(payment);

        System.out.println("Payment status: " + payment.getPaymentStatus());
    }
}
