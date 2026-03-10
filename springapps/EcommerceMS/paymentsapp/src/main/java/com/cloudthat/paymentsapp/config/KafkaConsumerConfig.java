package com.cloudthat.paymentsapp.config;

import com.cloudthat.paymentsapp.entities.OrderEvent;
import com.cloudthat.paymentsapp.services.PaymentService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;

import java.util.function.Consumer;

@Configuration
public class KafkaConsumerConfig {
    @Autowired
    private PaymentService paymentService;

    @Bean
    public Consumer<OrderEvent> processPayment() {
        return event -> {
            // This code runs automatically whenever a message hits the Kafka topic
            paymentService.processOrderPayment(event);
        };
    }
}
