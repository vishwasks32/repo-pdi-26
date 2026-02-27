package com.cloudthat;

import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;

@Configuration
public class BeanConfig {

    @Bean
    public User user(){
        PhoneNumber p = new PhoneNumber("+91","1234567890");

        User u = new User();
        u.setUserName("Vishwas");
        u.setEmailId("vishwas@cloudthat.com");
        u.setPhoneNumber(p);

        return u;

    }
}
