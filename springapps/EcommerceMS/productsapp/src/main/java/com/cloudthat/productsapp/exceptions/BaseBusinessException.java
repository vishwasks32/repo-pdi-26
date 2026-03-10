package com.cloudthat.productsapp.exceptions;

import com.cloudthat.productsapp.exceptions.ErrorType;

public class BaseBusinessException extends RuntimeException {
    private final ErrorType errorType;
    public BaseBusinessException(String message, ErrorType errorType) {
        super(message);
        this.errorType = errorType;
    }

    public  ErrorType getErrorType(){ return errorType; }
}
