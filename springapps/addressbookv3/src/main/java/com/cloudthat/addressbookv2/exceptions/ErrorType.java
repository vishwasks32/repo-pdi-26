package com.cloudthat.addressbookv2.exceptions;

import org.springframework.http.HttpStatus;

public enum ErrorType {
    CONTACT_NOT_FOUND(HttpStatus.NOT_FOUND, "The requested contact does not exist"),
    DUPLICATE_CONTACT(HttpStatus.CONFLICT, "A contact with this email already exists");

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
