package com.cloudthat;


import org.springframework.context.ApplicationContext;
import org.springframework.context.support.ClassPathXmlApplicationContext;

//TIP To <b>Run</b> code, press <shortcut actionId="Run"/> or
// click the <icon src="AllIcons.Actions.Execute"/> icon in the gutter.
public class Main {
    public static void main(String[] args) {
        ApplicationContext ctx = new ClassPathXmlApplicationContext("spring.xml");

        User u1 = (User) ctx.getBean("user");

        System.out.println("User name:" + u1.getUserName());
        System.out.println("User email id: "+ u1.getEmailId());
    }
}