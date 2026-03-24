package com.cloudthat.addressbookv3.dtos;

public record ApiResponse<T>(
        Boolean success,
        String message,
        T data,
        Long timestamp
) {
    public ApiResponse{
        if(timestamp == 0){
            timestamp = System.currentTimeMillis();
        }

    }
}
