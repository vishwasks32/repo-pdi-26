package com.cloudthat.ordersapp.models;


import java.time.Instant;

public class OrdersModel {

        private long id;


        private long productId;


        private long quantity;


        private Instant orderDate;


        private String orderStatus;


        private long amount;

        public long getId() {
            return id;
        }

        public void setId(long id) {
            this.id = id;
        }

        public long getProductId() {
            return productId;
        }

        public void setProductId(long productId) {
            this.productId = productId;
        }

        public long getQuantity() {
            return quantity;
        }

        public void setQuantity(long quantity) {
            this.quantity = quantity;
        }

        public Instant getOrderDate() {
            return orderDate;
        }

        public void setOrderDate(Instant orderDate) {
            this.orderDate = orderDate;
        }

        public String getOrderStatus() {
            return orderStatus;
        }

        public void setOrderStatus(String orderStatus) {
            this.orderStatus = orderStatus;
        }

        public long getAmount() {
            return amount;
        }

        public void setAmount(long amount) {
            this.amount = amount;
        }

}
