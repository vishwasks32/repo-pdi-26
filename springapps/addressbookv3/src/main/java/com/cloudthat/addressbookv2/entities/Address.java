package com.cloudthat.addressbookv2.entities;

import jakarta.persistence.Embeddable;
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
    private String addressLine2;

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


    public Integer getDoorNumber() {
        return doorNumber;
    }

    public void setDoorNumber(Integer doorNumber) {
        this.doorNumber = doorNumber;
    }

    public String getBuilding() {
        return building;
    }

    public void setBuilding(String building) {
        this.building = building;
    }

    public String getAddressLine1() {
        return addressLine1;
    }

    public void setAddressLine1(String addressLine1) {
        this.addressLine1 = addressLine1;
    }

    public String getAddressLine2() {
        return addressLine2;
    }

    public void setAddressLine2(String addressLine2) {
        this.addressLine2 = addressLine2;
    }

    public String getCity() {
        return city;
    }

    public void setCity(String city) {
        this.city = city;
    }

    public String getState() {
        return state;
    }

    public void setState(String state) {
        this.state = state;
    }

    public String getZipcode() {
        return zipcode;
    }

    public void setZipcode(String zipcode) {
        this.zipcode = zipcode;
    }

    public Address() {
    }
}
