package com.cloudthat.addressbookv3.dtos;

public record AddressModel(
   Integer doorNumber,
   String building,
   String addressLine1,
   String addressLine2,
   String city,
   String state,
   String zipcode
) {
}
