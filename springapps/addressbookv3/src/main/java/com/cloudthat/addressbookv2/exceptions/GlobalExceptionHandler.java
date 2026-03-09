package com.cloudthat.addressbookv2.exceptions;


import lombok.extern.slf4j.Slf4j;
import org.jspecify.annotations.Nullable;
import org.springframework.http.*;

import org.springframework.web.bind.MethodArgumentNotValidException;

import org.springframework.web.bind.annotation.ExceptionHandler;
import org.springframework.web.bind.annotation.RestControllerAdvice;

import org.springframework.web.context.request.WebRequest;
import org.springframework.web.servlet.mvc.method.annotation.ResponseEntityExceptionHandler;

import java.util.Map;
import java.util.stream.Collectors;

@Slf4j
@RestControllerAdvice
public class GlobalExceptionHandler extends ResponseEntityExceptionHandler {

    @Override
    public ResponseEntity<Object> handleMethodArgumentNotValid(
            MethodArgumentNotValidException ex,
            HttpHeaders headers,
            HttpStatusCode statusCode,
            WebRequest request) {
        ProblemDetail problemDetail = ProblemDetail.forStatusAndDetail(
                statusCode,
                "Validation failed for one or more fields");
        problemDetail.setTitle("Constraint Violation");

        Map<String, String > errors = ex.getBindingResult().getFieldErrors()
                .stream()
                .collect(Collectors.toMap(
                        error -> error.getField(),
                        error -> error.getDefaultMessage() != null? error.getDefaultMessage() : "Invalid Value"
                ));

        problemDetail.setProperty("errors", errors);

        return new ResponseEntity<>(problemDetail,headers, statusCode);
    }

    @ExceptionHandler(BaseBusinessException.class)
    public ProblemDetail handleBusinessExceptions(BaseBusinessException ex){
        ErrorType errorType = ex.getErrorType();

        ProblemDetail problemDetail = ProblemDetail.forStatusAndDetail(
                HttpStatus.BAD_REQUEST,
                ex.getMessage()
        );

        problemDetail.setTitle(errorType.name());

        return problemDetail;
    }

    @ExceptionHandler(Exception.class)
    public ProblemDetail handleAll(Exception ex){
        logger.debug("Global Handler Caught: "+getClass().getName());
        return ProblemDetail.forStatusAndDetail(HttpStatus.INTERNAL_SERVER_ERROR, ex.getMessage());
    }
}
