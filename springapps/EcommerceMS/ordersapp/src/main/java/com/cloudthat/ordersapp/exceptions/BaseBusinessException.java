package com.cloudthat.ordersapp.exceptions;

public class BaseBusinessException extends RuntimeException {
    private final ErrorType errorType;
    public BaseBusinessException(String message, ErrorType errorType) {
        super(message);
        this.errorType = errorType;
    }

    public  ErrorType getErrorType(){ return errorType; }
}
