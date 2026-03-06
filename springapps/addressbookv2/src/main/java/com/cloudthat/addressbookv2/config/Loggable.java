package com.cloudthat.addressbookv2.config;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

public interface Loggable {
    default Logger log(){
        return LoggerFactory.getLogger(this.getClass());
    }
}
