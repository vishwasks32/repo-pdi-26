package com.cloudthat.ordersapp.external;

import feign.Response;
import feign.codec.ErrorDecoder;
import lombok.extern.slf4j.Slf4j;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import tools.jackson.databind.ObjectMapper;

@Slf4j
public class CustomErrorDecoder implements ErrorDecoder {
    private static final Logger log = LoggerFactory.getLogger(CustomErrorDecoder.class);

    @Override
    public Exception decode(String s, Response response) {
        ObjectMapper objectMapper
                = new ObjectMapper();

        log.info("::{}", response.request().url());
        log.info("::{}", response.request().headers());
        log.info("::{}",response.body());

        return new Exception("Exception Occured");
    }
}
