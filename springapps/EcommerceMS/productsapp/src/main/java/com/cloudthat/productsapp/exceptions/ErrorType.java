package com.cloudthat.productsapp.exceptions;

import org.springframework.http.HttpStatus;

public enum ErrorType {
    PRODUCT_NOT_FOUND(HttpStatus.NOT_FOUND, "The requested product does not exist");
//    DUPLICATE_CONTACT(HttpStatus.CONFLICT, "A contact with this email already exists");

    private final HttpStatus status;
    private final String message;

    ErrorType(HttpStatus httpStatus, String s) {
        this.status = httpStatus;
        this.message = s;
    }

    public HttpStatus getStatus() {
        return status;
    }

    public String getMessage() {
        return message;
    }
}
