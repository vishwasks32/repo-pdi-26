package com.cloudthat.addressbookv2.config;

import org.springframework.boot.context.properties.ConfigurationProperties;
import org.springframework.context.annotation.Configuration;

@Configuration
@ConfigurationProperties(prefix = "app")
public class AppConfig {

    private String helpEmail;

    public String getHelpEmail() {
        return helpEmail;
    }

    public void setHelpEmail(String helpEmail) {
        this.helpEmail = helpEmail;
    }
}
