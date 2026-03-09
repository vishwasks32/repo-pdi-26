package com.cloudthat.productsapp;

import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.cloud.client.discovery.EnableDiscoveryClient;

@SpringBootApplication
@EnableDiscoveryClient
public class ProductsappApplication {

	public static void main(String[] args) {
		SpringApplication.run(ProductsappApplication.class, args);
	}

}
