package org.example;
import java.util.ArrayList;
import java.util.List;
import java.util.Comparator;

public class Main {
    public static void main(String[] args) {
        List<Product> products = new ArrayList<>();

        products.add(new Product("Laptop",
                999.99));
        products.add(new Product("Smartphone",
                599.99));
        products.add(new Product("Headphones", 149.99));

        // Iterate through the list and print product details
//        for (Product product : products) {
//            System.out.println(product);
//        }

        // Printing a list based on the price
        List<Product> sortedProducts = products.stream()
                .sorted(Comparator.comparing(Product::getPrice))
                .toList();

        System.out.println("Printing the Sorted Product list based on price: ");
        for(Product p: sortedProducts){
            System.out.println(p);
        }
    }
}