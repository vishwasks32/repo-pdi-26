package com.cloudthat.ordersapp;

import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.cloud.client.discovery.EnableDiscoveryClient;

@SpringBootApplication
@EnableDiscoveryClient
public class OrdersappApplication {

	public static void main(String[] args) {
		SpringApplication.run(OrdersappApplication.class, args);
	}

}
