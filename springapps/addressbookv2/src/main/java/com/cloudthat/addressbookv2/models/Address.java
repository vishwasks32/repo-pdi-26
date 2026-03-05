package com.cloudthat.addressbookv2.models;

import jakarta.persistence.Embeddable;
import jakarta.persistence.GeneratedValue;
import jakarta.persistence.GenerationType;
import jakarta.persistence.Id;
import jakarta.validation.constraints.Digits;
import jakarta.validation.constraints.NotBlank;
import jakarta.validation.constraints.Pattern;
import jakarta.validation.constraints.Positive;
import org.hibernate.validator.constraints.Length;

@Embeddable
public class Address {

    @Positive(message = "Door Number cannot be -ve or 0")
    @Digits(integer=5, fraction=0)
    private Integer doorNumber;
    private String building;
    @Pattern(regexp = "^[a-zA-Z0-9]+$")
    private String addressLine1;
    @Pattern(regexp = "^[a-zA-Z0-9]+$")
    private String AddressLine2;

    @NotBlank
    @Length(min=3, max = 30)
    private  String city;

    @NotBlank
    @Length(min=3, max = 30)
    private  String state;

    @NotBlank
    @Positive
    @Digits(integer = 6, fraction = 0)
    @Length(min = 6, max = 6)
    private String zipcode;
}
