package com.cloudthat.addressbookv2.entities;

import com.fasterxml.jackson.annotation.JsonBackReference;
import jakarta.persistence.*;
import jakarta.validation.constraints.Digits;
import jakarta.validation.constraints.NotBlank;
import jakarta.validation.constraints.Pattern;

@Entity
public class PhoneNumber {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long id;

    @NotBlank
    @Pattern(regexp = "^\\+[1-9]\\d{0,3}$")
    private String countryCode;

    @Digits(integer = 10, fraction = 0)
    private Integer number;

    @ManyToOne
    @JoinColumn(name = "contactId")
    @JsonBackReference
    private Contact contact;

    @Enumerated(EnumType.ORDINAL)
    private PhoneType phoneType;

    public Long getId() {
        return id;
    }

    public void setId(Long id) {
        this.id = id;
    }

    public String getCountryCode() {
        return countryCode;
    }

    public void setCountryCode(String countryCode) {
        this.countryCode = countryCode;
    }

    public Integer getNumber() {
        return number;
    }

    public void setNumber(Integer number) {
        this.number = number;
    }

    public Contact getContact() {
        return contact;
    }

    public void setContact(Contact contact) {
        this.contact = contact;
    }

    public PhoneType getPhoneType() {
        return phoneType;
    }

    public void setPhoneType(PhoneType phoneType) {
        this.phoneType = phoneType;
    }

    public PhoneNumber() {
    }

    @Override
    public String toString() {
        return "PhoneNumber{" +
                "id=" + id +
                ", countryCode='" + countryCode + '\'' +
                ", number=" + number +
                ", contact=" + contact +
                ", phoneType=" + phoneType +
                '}';
    }
}
