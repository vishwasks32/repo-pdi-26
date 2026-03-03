package com.cloudthat.addressbookv2.models;

import jakarta.persistence.*;

@Entity
public class PhoneNumber {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long id;

    private String countryCode;
    private Integer number;

    @ManyToOne
    private Contact contact;

    @Enumerated(EnumType.ORDINAL)
    private PhoneType phoneType;

}
